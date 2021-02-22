using System;

namespace TrendFox.Common
{
    /// <summary>
    /// Service for getting the current time.
    /// </summary>
    public interface ITime
    {
        /// <summary>
        /// Get the current time.
        /// </summary>
        DateTimeOffset Now { get; }   
    }
}