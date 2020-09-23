using Newtonsoft.Json;
using System.Collections.Generic;

namespace W3W
{
    public class What3WordsSuggestionCollection
    {
        [JsonProperty(PropertyName = "suggestions")]
        public List<What3WordsSuggestion> Suggestions { get; set; }
    }
}
