using System;

namespace W3W
{
    public class What3WordsException : Exception
    {
        public What3WordsException(string message) : base(message) { }

        public What3WordsException(string code, string message) : this($"{code}: {message}") { }

        public What3WordsException(What3WordsError error) : this(error.Code, error.Message) { }
    }
}
