using System;

namespace GitHookController.Exceptions
{
    [Serializable]
    public class InvalidPayloadModelException : Exception
    {
        public InvalidPayloadModelException()
            :base("Payload model is invalid. Check the remote response.")
        {
            
        }
    }
}
