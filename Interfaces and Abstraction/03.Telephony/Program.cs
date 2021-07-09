using System;
using System.Linq;

namespace _03.Telephony
{
    using _03.Telephony.Models;
    using _03.Telephony.Exceptions;
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split().ToArray();
            string[] urls = Console.ReadLine().Split().ToArray();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currPhoneNumber = phoneNumbers[i];

                try
                {
                    if (currPhoneNumber.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(currPhoneNumber));
                    }
                    else
                    {
                        Console.WriteLine(smartphone.Call(currPhoneNumber));
                    }
                }
                catch (InvalidPhoneNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];

                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidUrlException ex)
                {
                    Console.WriteLine(ex.Message);
                    
                }
                
            }
        }
    }
}
