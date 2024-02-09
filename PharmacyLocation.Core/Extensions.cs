using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyLocation.Core
{
    public static class Extensions
    {
        public static string TimeSpanToFriendlyString(this TimeSpan span)
        {
            string formatted = "";

            if (span.Days > 0)
            {
                formatted += $"{span.Days} día{(span.Days != 1 ? "s" : "")} ";
            }

            if (span.Hours > 0)
            {
                formatted += $"{span.Hours} hora{(span.Hours != 1 ? "s" : "")} ";
            }

            if (span.Minutes > 0)
            {
                formatted += $"{span.Minutes} minuto{(span.Minutes != 1 ? "s" : "")} ";
            }

            if (span.Seconds > 0)
            {
                formatted += $"{span.Seconds} segundo{(span.Seconds != 1 ? "s" : "")} ";
            }

            if (string.IsNullOrEmpty(formatted))
            {
                formatted = "0 segundos";
            }

            return formatted.Trim();
        }
    }
}
