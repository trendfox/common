using System;

namespace TrendFox.Common
{
    public static class DateTimeOffsetExtensions
    {
        public static DateTimeOffset RoundNearest(this DateTimeOffset value, TimeSpan delta)
        {
            var newTicks = (value.Ticks + (delta.Ticks / 2) - 1)
                / delta.Ticks
                * delta.Ticks;
            return new DateTimeOffset(newTicks, value.Offset);
        }
    }
}