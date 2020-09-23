using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsConversion
    {
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; } = "";

        [JsonProperty(PropertyName = "square")]
        public BoundingBox Square { get; set; }

        [JsonProperty(PropertyName = "nearestPlace")]
        public string NearestPlace { get; set; } = "";

        [JsonProperty(PropertyName = "coordinates")]
        public LatLng Coordinates { get; set; }

        [JsonProperty(PropertyName = "words")]
        public string Words { get; set; } = "";

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; } = "";

        [JsonProperty(PropertyName = "map")]
        public string Map { get; set; } = "";
    }
}
