using System;

namespace TrendFox.Common
{
    /// <summary>
    /// Implements <see cref="ITime" /> using a fixed time.
    /// </summary>
    public class FixedTime
        : ITime
    {
        /// <summary>
        /// Get the fixed time for this instance.
        /// </summary>
        public DateTimeOffset Now { get; private set; }

        /// <summary>
        /// Creates a new instance using a fixed time.
        /// </summary>
        /// <param name="time">The time to be used.</param>
        public FixedTime(DateTimeOffset time)
        {
            SetTime(time);
        }

        /// <summary>
        /// Changes the fixed time of this instance.
        /// </summary>
        /// <param name="time">The new time.</param>
        public void SetTime(DateTimeOffset time)
        {
            Now = time;
        }
    }
}