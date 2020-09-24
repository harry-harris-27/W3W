using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsLine
    {
        [JsonConstructor]
        public What3WordsLine(LatLng start, LatLng end)
        {
            this.Start = start;
            this.End = end;
        }


        [JsonProperty(PropertyName = "start")]
        public LatLng Start { get; }

        [JsonProperty(PropertyName = "end")]
        public LatLng End { get; }


        public override string ToString() => $"{Start}.{End}";
    }
}
