using System;
using Xunit;

namespace TrendFox.Common.Tests
{
    public class SystemUtcTimeTests
    {
        [Fact]
        public void ReturnsSystemUtcTime()
        {
            var svc = new SystemUtcTime();

            var expectedMin = DateTimeOffset.UtcNow;
            var actual = svc.Now;
            var expectedMax = DateTimeOffset.UtcNow;

            Assert.InRange(actual, expectedMin, expectedMax);
        }
    }
}