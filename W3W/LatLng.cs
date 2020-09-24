using Newtonsoft.Json;

namespace W3W
{
    public class LatLng
    {
        [JsonConstructor]
        public LatLng(double lat, double lng)
        {
            Latitude = lat;
            Longitude = lng;
        }


        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; } = 0;

        [JsonProperty(PropertyName = "lng")]
        public double Longitude { get; } = 0;


        public override string ToString() => $"{Latitude},{Longitude}";
    }
}
