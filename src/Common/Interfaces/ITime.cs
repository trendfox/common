using System;

namespace TrendFox.Common
{
    public interface ITime
    {
        /// <summary>
        /// Get the current time.
        /// </summary>
        DateTimeOffset Now { get; }   
    }
}