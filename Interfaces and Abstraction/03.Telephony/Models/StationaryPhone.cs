namespace _03.Telephony.Models
{
    using System.Linq;
    using _03.Telephony.Interfaces;
    using _03.Telephony.Exceptions;
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }
    }
}
