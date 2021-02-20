using System;

namespace TrendFox.Common
{
    public interface ITime
    {
        DateTimeOffset Now { get; }   
    }
}