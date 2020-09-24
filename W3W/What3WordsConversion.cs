using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsConversion
    {
        [JsonConstructor]
        public What3WordsConversion(string country, BoundingBox square, string nearestPlace, 
            LatLng coordinates, string words, string language, string map)
        {
            this.Country = country;
            this.Square = square;
            this.NearestPlace = nearestPlace;
            this.Coordinates = coordinates;
            this.Words = words;
            this.Language = language;
            this.Map = map;
        }


        [JsonProperty(PropertyName = "country")]
        public string Country { get; } = "";

        [JsonProperty(PropertyName = "square")]
        public BoundingBox Square { get; }

        [JsonProperty(PropertyName = "nearestPlace")]
        public string NearestPlace { get; } = "";

        [JsonProperty(PropertyName = "coordinates")]
        public LatLng Coordinates { get; }

        [JsonProperty(PropertyName = "words")]
        public string Words { get; } = "";

        [JsonProperty(PropertyName = "language")]
        public string Language { get; } = "";

        [JsonProperty(PropertyName = "map")]
        public string Map { get; } = "";
    }
}
