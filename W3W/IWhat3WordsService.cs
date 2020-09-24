using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace W3W
{
    public interface IWhat3WordsService
    {

        /// <summary>
        /// Gets or sets a value indicating whether the results of API queries should be cached.
        /// </summary>
        /// <remarks>
        /// The can be a useful techinque to reduce the number of quoted API results and increase performance.
        /// </remarks>
        bool CacheResults { get; set; }


        /// <summary>
        /// Converts the specified latitude and longitude to a 3-word address, in the specified language.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="language">A supported 3 word address language letter code.</param>
        /// <returns></returns>
        Task<What3WordsConversion> ConvertAsync(double latitude, double longitude, string language);

        /// <summary>
        /// Converts the specified 3-word address in a latitude and longitude.
        /// </summary>
        /// <param name="words">The 3-word address to convert.</param>
        /// <returns></returns>
        Task<What3WordsConversion> ConvertAsync(string words);

        /// <summary>
        /// Suggests a list of valid 3 word address from a slightly incorrect 3 word address.
        /// </summary>
        /// <param name="input">The input 3-word address.</param>
        /// <param name="options">The AutoSuggest options.</param>
        /// <returns></returns>
        Task<What3WordsSuggestionCollection> AutoSuggestAsync(string input, What3WordsAutoSuggestOptions options);

        /// <summary>
        /// Returns a section of the 3mx3m what3words grid for the specified <paramref name="boundingBox"/>.
        /// </summary>
        /// <param name="boundingBox">The bounding box.</param>
        /// <returns></returns>
        /// <remarks>
        /// The request bounding box must not exceed 4km from corner to corner or a 'BadBoundingBoxTooBig'
        /// error will be thrown.
        /// </remarks>
        Task<What3WordsLineCollection> GridSectionAsync(BoundingBox boundingBox);

        /// <summary>
        /// Returns all the available 3 word address languages.
        /// </summary>
        /// <returns></returns>
        Task<What3WordsLanguageCollection> AvailableLanguagesAsync();
    }
}
