using System;
using Xunit;

namespace TrendFox.Common.Tests
{
    public class DateTimeExtensionsTests
    {
        [Theory]
        [InlineData("2021-01-01 17:00", 15, "2021-01-01 17:00")]
        [InlineData("2021-01-01 17:15", 15, "2021-01-01 17:15")]
        [InlineData("2021-01-01 17:07:30", 15, "2021-01-01 17:00")]
        [InlineData("2021-01-01 17:07:30.1", 15, "2021-01-01 17:15")]
        [InlineData("2021-01-01 17:00", 60, "2021-01-01 17:00")]
        [InlineData("2021-01-01 17:15", 60, "2021-01-01 17:00")]
        [InlineData("2021-01-01 17:30", 60, "2021-01-01 17:00")]
        [InlineData("2021-01-01 17:30:00.1", 60, "2021-01-01 18:00")]
        public void RoundNearestWorks(string rawInput, int minutes, string rawExpected)
        {
            var expected = DateTime.Parse(rawExpected);
            var input = DateTime.Parse(rawInput);
            var actual = input.RoundNearest(TimeSpan.FromMinutes(minutes));
            Assert.Equal(expected, actual);
        }
    }
}