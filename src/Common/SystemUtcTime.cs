using System;

namespace TrendFox.Common
{
    /// <summary>
    /// Implement <see cref="ITime" /> using the current system UTC time.
    /// </summary>
    public class SystemUtcTime
        : ITime
    {
        /// <summary>
        /// Get the current UTC time.
        /// </summary>
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}