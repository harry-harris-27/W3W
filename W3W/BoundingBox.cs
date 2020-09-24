using Newtonsoft.Json;

namespace W3W
{
    public class BoundingBox
    {
        [JsonConstructor]
        public BoundingBox(LatLng southWest, LatLng northEast)
        {
            this.SouthWest = southWest;
            this.NorthEast = northEast;
        }


        [JsonProperty(PropertyName = "northeast")]
        public LatLng NorthEast { get; }

        [JsonProperty(PropertyName = "southwest")]
        public LatLng SouthWest { get; }


        public override string ToString() => $"{SouthWest},{NorthEast}";
    }
}
