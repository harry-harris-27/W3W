using Newtonsoft.Json;

namespace W3W
{
    public class What3WordsError
    {
        [JsonConstructor]
        public What3WordsError(string code, string message)
        {
            Code = code;
            Message = message;
        }


        [JsonProperty(PropertyName = "code")]
        public string Code { get; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; }


        public What3WordsException AsException() => new What3WordsException(Code, Message);

    }
}
