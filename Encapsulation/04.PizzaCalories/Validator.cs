using System;
using System.Globalization;

namespace _04.PizzaCalories
{
    public static class Validator
    {
        public static void ThrowIfNumberIsNotInRange(int min, int max, int number, string exceptionMessage)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
