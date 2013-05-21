using System;

namespace GitHookController.Exceptions
{
    [Serializable]
    public class InvalidPayloadException : Exception
    {
        public InvalidPayloadException()
            : base("Payload is not available.")
        { }
    }
}