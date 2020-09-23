using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsSuggestion
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "nearestPlace")]
        public string NearestPlace { get; set; }

        [JsonProperty(PropertyName = "words")]
        public string Words { get; set; }

        [JsonProperty(PropertyName = "distanceToFocusKm")]
        public double DistanceToFocus { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
    }
}
