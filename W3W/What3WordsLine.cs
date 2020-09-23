using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsLine
    {
        [JsonProperty(PropertyName = "start")]
        public LatLng Start { get; set; }

        [JsonProperty(PropertyName = "end")]
        public LatLng End { get; set; }
    }
}
