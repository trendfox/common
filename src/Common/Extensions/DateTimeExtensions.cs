using System;

namespace TrendFox.Common
{
    public static class DateTimeExtensions
    {
        public static DateTime RoundNearest(this DateTime value, TimeSpan delta)
        {
            var newTicks = (value.Ticks + (delta.Ticks / 2) - 1)
                / delta.Ticks
                * delta.Ticks;
            return new DateTime(newTicks, value.Kind);
        }
    }
}