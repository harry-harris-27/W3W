using Newtonsoft.Json;
using System.Collections.Generic;

namespace W3W
{
    public class What3WordsLineCollection
    {
        [JsonConstructor]
        public What3WordsLineCollection(List<What3WordsLine> lines)
        {
            this.Lines = lines;
        }


        [JsonProperty(PropertyName = "lines")]
        public IEnumerable<What3WordsLine> Lines { get; }


        public override string ToString() => string.Join(",", Lines);
    }
}
