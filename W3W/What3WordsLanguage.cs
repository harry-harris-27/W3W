using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsLanguage
    {
        [JsonConstructor]
        public What3WordsLanguage(string nativeName, string code, string name)
        {
            this.NativeName = nativeName;
            this.Code = code;
            this.Name = name;
        }


        [JsonProperty(PropertyName = "nativeName")]
        public string NativeName { get; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; }
    }
}
