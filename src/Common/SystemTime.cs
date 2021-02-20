using System;

namespace TrendFox.Common
{
    public class SystemTime
        : ITime
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}