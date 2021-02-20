using System;

namespace TrendFox.Common
{
    /// <summary>
    /// Implement <see cref="ITime" /> using the current system UTC time.
    /// </summary>
    public class SystemUtcTime
        : ITime
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}