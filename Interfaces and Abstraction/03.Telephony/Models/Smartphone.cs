namespace _03.Telephony.Models
{
    using System.Linq;
    using _03.Telephony.Interfaces;
    using _03.Telephony.Exceptions;

    public class Smartphone : ICallable, IBrowsebale
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return $"Calling... {phoneNumber}";
            
        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidUrlException();
            }

            return $"Browsing: {url}!";
        }
    }
}
