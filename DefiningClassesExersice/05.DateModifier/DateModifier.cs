using System;
using System.Globalization;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static double DifferenceBetweenDays(string firstDate, string secondDate)
        {
            DateTime date1 = DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            return Math.Abs((date2 - date1).TotalDays);
        }
    }
}
