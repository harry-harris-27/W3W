using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace W3W
{
    public class What3WordsService : IWhat3WordsService
    {

        private const string API_BASE_URL = "https://api.what3words.com/v3/";

        private readonly IDictionary<string, object> cache = new ConcurrentDictionary<string, object>();

        private readonly HttpClient httpClient;

        private bool cacheResults = true;


        /// <summary>
        /// Initializes a new instance of the <see cref="What3WordsService"/> class.
        /// </summary>
        /// <param name="apiKey">The what3words API key.</param>
        /// <exception cref="System.InvalidOperationException">API key cannot be null or empty</exception>
        public What3WordsService(string apiKey) : this(apiKey, API_BASE_URL) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="What3WordsService"/> class.
        /// </summary>
        /// <param name="apiKey">The what3words API key.</param>
        /// <param name="apiBaseUrl">The base URL of the what3words API.</param>
        /// <exception cref="System.InvalidOperationException">API key cannot be null or empty</exception>
        public What3WordsService(string apiKey, string apiBaseUrl)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("API key cannot be null or empty");
            if (string.IsNullOrWhiteSpace(apiBaseUrl))
                throw new ArgumentException("API base URL cannot be null or empty");
                        
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiBaseUrl);
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        }


        /// <summary>
        /// Gets or sets a value indicating whether the results of API queries should be cached.
        /// </summary>
        /// <remarks>
        /// The can be a useful techinque to reduce the number of quoted API results and increase performance.
        /// </remarks>
        public bool CacheResults
        {
            get => cacheResults;
            set
            {
                cacheResults = value;
                if (!cacheResults)
                {
                    cache.Clear();
                }
            }
        }

        /// <inheritdoc/>
        public Task<What3WordsConversion> ConvertAsync(double latitude, double longitude, string language)
        {
            var parameters = new Dictionary<string, string>
            {
                { "coordinates", $"{latitude},{longitude}" }
            };
            return GetAsync<What3WordsConversion>("convert-to-3wa", parameters);
        }

        /// <inheritdoc/>
        public Task<What3WordsConversion> ConvertAsync(string words)
        {
            if (!this.IsAddressValid(words)) throw new ArgumentException("Invalid 3 word address", nameof(words));

            var parameters = new Dictionary<string, string>
            {
                { "words", words }
            };
            return GetAsync<What3WordsConversion>("convert-to-coordinates", parameters);
        }

        /// <inheritdoc/>
        public Task<What3WordsSuggestionCollection> AutoSuggestAsync(string input, What3WordsAutoSuggestOptions options)
        {
            var parameters = OptionsToParameters(options ?? new What3WordsAutoSuggestOptions());
            parameters.Add("input", input);
            return GetAsync<What3WordsSuggestionCollection>("autosuggest", parameters);
        }

        /// <inheritdoc/>
        public Task<What3WordsLineCollection> GridSectionAsync(BoundingBox boundingBox)
        {
            if (boundingBox == null) throw new ArgumentNullException(nameof(boundingBox));

            var parameters = new Dictionary<string, string>
            {
                { "bounding-box", boundingBox.ToString() }
            };
            return GetAsync<What3WordsLineCollection>("grid-section", parameters);
        }

        /// <inheritdoc/>
        public async Task<What3WordsLanguageCollection> AvailableLanguagesAsync()
        {
            var result = await GetAsync<What3WordsLanguageCollection>("available-languages");
            return result;
        }


        private async Task<T> GetAsync<T>(string url, IDictionary<string, string> parameters = null)
        {
            // If any parameters provided, append them to the url
            if (parameters != null && parameters.Any())
            {
                url += "?" + string.Join("&", parameters.Select(kvp => $"{ WebUtility.UrlEncode(kvp.Key) }={ WebUtility.UrlEncode(kvp.Value) }"));
            }

            // If caching results, check is we have already requested this url
            if (CacheResults && cache.TryGetValue(url, out object cachedResponse))
            {
                return (T)cachedResponse;
            }

            // Execute the GET request from the API
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                await HandleUnsuccessfulResponse(response);
            }

            // Deserialize the content of the response
            string json = await response.Content.ReadAsStringAsync();
            T content = JsonConvert.DeserializeObject<T>(json);

            // If using the cache, add the response to it
            if (CacheResults)
            {
                cache.Add(url, content);
            }

            return content;
        }

        private static async Task HandleUnsuccessfulResponse(HttpResponseMessage responseMessage)
        {
            string content = await responseMessage.Content.ReadAsStringAsync();

            switch (responseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    var error = JsonConvert.DeserializeObject<What3WordsError>(content);
                    throw error.AsException();

                case HttpStatusCode.Unauthorized:
                    throw new What3WordsException("Invalid API Key");

                case HttpStatusCode.NotFound:
                    throw new What3WordsException("URL not found, Check the URL of the endpoint your're trying to reach.");

                case HttpStatusCode.MethodNotAllowed:
                    throw new What3WordsException("Method not allowed. You must use a GET request.");

                default:
                    throw new Exception(responseMessage.ReasonPhrase + ": " + content);
            }
        }

        private static IDictionary<string, string> OptionsToParameters(What3WordsAutoSuggestOptions options)
        {
            var parameters = new Dictionary<string, string>
            {
                { "n-results", options.Limit.ToString() },
                { "language", options.Language },
                { "prefer-land", options.PreferLand.ToString().ToLowerInvariant() }
            };

            if (options.Focus != null)
            {
                parameters.Add("focus", options.Focus.ToString());
                parameters.Add("n-focus-results", options.FocusLimit.ToString());
            }
            if (options.ClipToBoundingBox != null)
            {
                parameters.Add("clip-to-bounding-box", options.ClipToBoundingBox.ToString());
            }
            if (options.ClipToCircle != null)
            {
                parameters.Add("clip-to-circle", options.ClipToCircle.ToString());
            }
            if (options.ClipToCountries != null)
            {
                parameters.Add("clip-to-country", string.Join(",", options.ClipToCountries));
            }
            if (options.ClipToPolygon != null && options.ClipToPolygon.Count > 3)
            {
                parameters.Add("clip-to-polygon", string.Join(",", options.ClipToPolygon.Select(x => x.ToString())));
            }

            return parameters;
        }

    }
}
