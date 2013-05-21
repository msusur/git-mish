using System;

namespace GitHookController.Exceptions
{
    [Serializable]
    public class InvalidRequestTypeException : Exception
    {
        public InvalidRequestTypeException(Uri url)
            : base(string.Format("'{0}' is invalid.", url))
        {

        }
    }
}