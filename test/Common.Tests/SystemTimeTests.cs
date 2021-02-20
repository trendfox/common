using System;
using Xunit;

namespace TrendFox.Common.Tests
{
    public class SystemTimeTests
    {
        [Fact]
        public void ReturnsSystemTime()
        {
            var svc = new SystemTime();

            var expectedMin = DateTimeOffset.Now;
            var actual = svc.Now;
            var expectedMax = DateTimeOffset.Now;

            Assert.InRange(actual, expectedMin, expectedMax);
        }
    }
}