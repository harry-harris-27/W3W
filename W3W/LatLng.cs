using Newtonsoft.Json;

namespace W3W
{
    public class LatLng
    {
        public LatLng() { }

        public LatLng(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }


        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; } = 0;

        [JsonProperty(PropertyName = "lng")]
        public double Longitude { get; set; } = 0;


        public override string ToString() => $"{Latitude},{Longitude}";
    }
}
