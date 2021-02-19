using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDSidekick.Commons.Services
{
    public static class ExtensionMethods
    {
        public static int Modifier(this int abilityScore) => Convert.ToInt32(Math.Floor(((float)abilityScore - 10) / 2));

        public static int Between(this int value, int min, int max)
        {
            if (value < min)
            { value = min; }
            else if (value > max)
            { value = max; }
            return value;
        }


        //public static int ExtractDigitsFrom(string text)
        //{
        //    int number = 0;
        //    if (Int32.TryParse(string.Concat(text.Where(char.IsDigit)), out number)) return number;
        //    throw new FormatException();
        //}
    }
}
