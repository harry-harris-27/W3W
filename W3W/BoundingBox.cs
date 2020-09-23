using Newtonsoft.Json;

namespace W3W
{
    public class BoundingBox
    {
        [JsonProperty(PropertyName = "northeast")]
        public LatLng NorthEast { get; set; }

        [JsonProperty(PropertyName = "southwest")]
        public LatLng SouthWest { get; set; }


        public override string ToString() => $"{SouthWest},{NorthEast}";
    }
}
