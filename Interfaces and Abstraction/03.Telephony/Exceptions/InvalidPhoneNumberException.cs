using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string InvalidNumberExceptionMessage = "Invalid number!";
        public InvalidPhoneNumberException():base(InvalidNumberExceptionMessage)
        {
            
        }
    }
}
