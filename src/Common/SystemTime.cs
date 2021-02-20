using System;

namespace TrendFox.Common
{
    /// <summary>
    /// Implement <see cref="ITime" /> using the current system time.
    /// </summary>
    public class SystemTime
        : ITime
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}