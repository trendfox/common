using System;
using Xunit;

namespace TrendFox.Common.Tests
{
    public class DateTimeOffsetExtensionsTests
    {
        [Theory]
        [InlineData("2021-01-01 17:00+01:00", 15, "2021-01-01 17:00+01:00")]
        [InlineData("2021-01-01 17:15+01:00", 15, "2021-01-01 17:15+01:00")]
        [InlineData("2021-01-01 17:07:30+01:00", 15, "2021-01-01 17:00+01:00")]
        [InlineData("2021-01-01 17:07:30.1+01:00", 15, "2021-01-01 17:15+01:00")]
        [InlineData("2021-01-01 17:00+01:00", 60, "2021-01-01 17:00+01:00")]
        [InlineData("2021-01-01 17:15+01:00", 60, "2021-01-01 17:00+01:00")]
        [InlineData("2021-01-01 17:30+01:00", 60, "2021-01-01 17:00+01:00")]
        [InlineData("2021-01-01 17:30:00.1+01:00", 60, "2021-01-01 18:00+01:00")]
        public void RoundNearestWorks(string rawInput, int minutes, string rawExpected)
        {
            var expected = DateTimeOffset.Parse(rawExpected);
            var input = DateTimeOffset.Parse(rawInput);
            var actual = input.RoundNearest(TimeSpan.FromMinutes(minutes));
            Assert.Equal(expected, actual);
        }
    }
}