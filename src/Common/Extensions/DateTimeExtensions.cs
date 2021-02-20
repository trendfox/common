using System;

namespace TrendFox.Common
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Rounds a <see cref="DateTime"/> to the nearest value
        /// depending on the specified <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="delta">The precision to round to.</param>
        /// <returns>The rounded value.</returns>
        public static DateTime RoundNearest(this DateTime value, TimeSpan delta)
        {
            var newTicks = (value.Ticks + (delta.Ticks / 2) - 1)
                / delta.Ticks
                * delta.Ticks;
            return new DateTime(newTicks, value.Kind);
        }
    }
}