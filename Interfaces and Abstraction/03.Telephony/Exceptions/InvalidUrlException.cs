using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidUrlException : Exception
    {
        private const string InvalidURlExceptionMessage = "Invalid URL!";

        public InvalidUrlException():base(InvalidURlExceptionMessage)
        {
            
        }
    }
}
