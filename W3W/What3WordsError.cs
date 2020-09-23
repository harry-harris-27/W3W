using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsError
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }


        public What3WordsException AsException() => new What3WordsException(Code, Message);

    }
}
