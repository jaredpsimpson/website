﻿using NodaTime;
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
            if (date == DateTime.MinValue)
                return date;

            if (date.Kind == DateTimeKind.Utc)
            {
                return Instant.FromDateTimeUtc(date)
                    .InZone(CentralTimeZone)
                    .ToDateTimeUnspecified();
            }
            else
            {
                return Instant.FromDateTimeOffset(date)
                    .InZone(CentralTimeZone)
                    .ToDateTimeUnspecified();
            }
        }
    }
}
