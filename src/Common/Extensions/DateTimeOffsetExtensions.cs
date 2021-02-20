using System;

namespace TrendFox.Common
{
    public static class DateTimeOffsetExtensions
    {
        /// <summary>
        /// Rounds a <see cref="DateTimeOffset"/> to the nearest value
        /// depending on the specified <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="delta">The precision to round to.</param>
        /// <returns>The rounded value.</returns>
        public static DateTimeOffset RoundNearest(this DateTimeOffset value, TimeSpan delta)
        {
            var newTicks = (value.Ticks + (delta.Ticks / 2) - 1)
                / delta.Ticks
                * delta.Ticks;
            return new DateTimeOffset(newTicks, value.Offset);
        }
    }
}