using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsSuggestion
    {
        [JsonConstructor]
        public What3WordsSuggestion(string country, string nearestPlace, string words, int rank, string language)
        {
            this.Country = country;
            this.NearestPlace = nearestPlace;
            this.Words = words;
            this.Rank = rank;
            this.Language = language;
        }


        [JsonProperty(PropertyName = "country")]
        public string Country { get; }

        [JsonProperty(PropertyName = "nearestPlace")]
        public string NearestPlace { get; }

        [JsonProperty(PropertyName = "words")]
        public string Words { get; }

        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; }
    }
}
