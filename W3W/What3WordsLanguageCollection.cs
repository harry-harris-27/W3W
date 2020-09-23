using Newtonsoft.Json;
using System.Collections.Generic;

namespace W3W
{
    public class What3WordsLanguageCollection
    {
        [JsonProperty("languages")]
        public List<What3WordsLanguage> Languages { get; set; }
    }
}
