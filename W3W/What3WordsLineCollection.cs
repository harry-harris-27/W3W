using Newtonsoft.Json;
using System.Collections.Generic;

namespace W3W
{
    public class What3WordsLineCollection
    {
        [JsonProperty(PropertyName = "lines")]
        public List<What3WordsLine> Lines { get; set; }
    }
}
