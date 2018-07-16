using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devfestweekend.Extensions
{
    public static class DateTimeExtensions
    {
        private static readonly DateTimeZone CentralTimeZone =
                DateTimeZoneProviders.Tzdb["US/Central"];
        public static DateTime ConvertToCentral(this DateTime date)
        {
            return Instant.FromDateTimeUtc(date)
                .InZone(CentralTimeZone)
                .ToDateTimeUnspecified();
        }
    }
}
