using Newtonsoft.Json;
using System.Collections.Generic;

namespace W3W
{
    public class What3WordsSuggestionCollection
    {
        [JsonConstructor]
        public What3WordsSuggestionCollection(List<What3WordsSuggestion> suggestions)
        {
            this.Suggestions = suggestions;
        }


        [JsonProperty(PropertyName = "suggestions")]
        public IEnumerable<What3WordsSuggestion> Suggestions { get; }
    }
}
