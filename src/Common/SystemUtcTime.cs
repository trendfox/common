using System;

namespace TrendFox.Common
{
    public class SystemUtcTime
        : ITime
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}