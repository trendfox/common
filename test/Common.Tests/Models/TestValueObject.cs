using System.Collections.Generic;

namespace TrendFox.Common.Tests
{
    public class TestValueObject
        : ValueObject
    {
        public string Value { get; }

        private TestValueObject(string value)
        {
            Value = value;
        }

        public static TestValueObject For(string value)
        {
            return new TestValueObject(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}