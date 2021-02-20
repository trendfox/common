using System;
using Xunit;

namespace TrendFox.Common.Tests
{
    public class FixedTimeTests
    {
        [Fact]
        public void ReturnsGivenTime()
        {
            var expected = DateTimeOffset.Now;
            var svc = new FixedTime(expected);
            var actual = svc.Now;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetTimeWorks()
        {
            var svc = new FixedTime(DateTimeOffset.Now);

            var expected = new DateTimeOffset(2020, 1, 1, 10, 52, 41, TimeSpan.FromHours(2));
            svc.SetTime(expected);
            var actual = svc.Now;

            Assert.Equal(expected, actual);
        }
    }
}