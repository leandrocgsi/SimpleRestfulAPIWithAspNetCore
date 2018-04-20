using System;
using System.Globalization;

namespace SimpleRestfulAPIWithAspNetCore.Utils
{
    public class DateUtils
    {
        public static DateTime? SafeParse(string value, string format)
        {
            if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else
            {
                return null;
            }
        }
    }
}
