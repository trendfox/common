using System.Collections.Generic;
using Xunit;

namespace TrendFox.Common.Tests
{
    public class ValueObjectTests
    {
        public static IEnumerable<object?[]> GetEqualityTestData()
        {
            yield return new object?[] { null, null, true };
            yield return new object?[] { TestValueObject.For(""), null, false };
            yield return new object?[] { null, TestValueObject.For("x"), false };
            yield return new object?[] { TestValueObject.For(""), TestValueObject.For("x"), false };
            yield return new object?[] { TestValueObject.For(""), TestValueObject.For(""), true };
            yield return new object?[] { TestValueObject.For(""), TestValueObject.For(null!), false };
            yield return new object?[] { TestValueObject.For(null!), TestValueObject.For(null!), true };
        }

        [Theory]
        [MemberData(nameof(GetEqualityTestData))]
        public void EqualsWorks(TestValueObject obj1, TestValueObject obj2, bool expected)
        {
            var actual = object.Equals(obj1, obj2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetEqualityTestData))]
        public void EqualOperatorWorks(TestValueObject obj1, TestValueObject obj2, bool expected)
        {
            var actual = obj1 == obj2;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetEqualityTestData))]
        public void EqualsSwappedWorks(TestValueObject obj1, TestValueObject obj2, bool expected)
        {
            var actual = object.Equals(obj2, obj1);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetEqualityTestData))]
        public void EqualOperatorSwappedWorks(TestValueObject obj1, TestValueObject obj2, bool expected)
        {
            var actual = obj2 == obj1;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HashcodesMatches()
        {
            var obj1 = TestValueObject.For("");
            var obj2 = TestValueObject.For("");
            Assert.True(obj1.GetHashCode() == obj2.GetHashCode());
        }

        [Fact]
        public void NotEqualOperatorWorks()
        {
            var obj1 = TestValueObject.For("a");
            var obj2 = TestValueObject.For("b");
            Assert.True(obj1 != obj2);
        }

        [Fact]
        public void NotEqualsNullWorks()
        {
            var obj1 = TestValueObject.For("a");
            object? obj2 = null;
            Assert.False(obj1.Equals(obj2));
        }

        [Fact]
        public void NotEqualsOnTypeMismatchWorks()
        {
            var obj1 = TestValueObject.For("a");
            var obj2 = new object();
            Assert.False(obj1.Equals(obj2));
        }
    }
}