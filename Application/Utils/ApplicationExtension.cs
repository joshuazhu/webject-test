using System;

namespace Application.Utils
{
    public static class ApplicationExtension
    {
        public const string LONG_DATE_TIME_FORMAT = "dddd hh:mm tt, dd MMMM yyyy";
        public const string SHORT_DATE_TIME_FORMAT = "dd MMMM yyyy";

        public static string ToWebjectLongDateTime(this DateTime dt)
        {
            return dt.ToString(LONG_DATE_TIME_FORMAT);
        }

        public static string ToWebjectShortDateTime(this DateTime dt)
        {
            return dt.ToString(SHORT_DATE_TIME_FORMAT);
        }
    }
}
