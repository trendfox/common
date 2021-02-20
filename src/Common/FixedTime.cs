using System;

namespace TrendFox.Common
{
    /// <summary>
    /// Implements <see cref="ITime" /> using a fixed time.
    /// </summary>
    public class FixedTime
        : ITime
    {
        public DateTimeOffset Now { get; private set; }

        public FixedTime(DateTimeOffset time)
        {
            SetTime(time);
        }

        public void SetTime(DateTimeOffset time)
        {
            Now = time;
        }
    }
}