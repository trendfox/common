using System.Collections.Generic;
using System.Linq;

namespace TrendFox.Common
{
    /// <summary>
    /// This ValueObject implementation is based on the microsoft example from
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </summary>
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right!);
        }

        protected static bool NotEqualOperator(ValueObject? left, ValueObject? right)
        {
            return !(EqualOperator(left, right));
        }

        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return NotEqualOperator(left, right);
        }

        protected abstract IEnumerable<object?> GetAtomicValues();

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;
            IEnumerator<object?> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object?> otherValues = other.GetAtomicValues().GetEnumerator();

            var thisAdvanced = thisValues.MoveNext();
            var otherAdvanced = otherValues.MoveNext();

            while (thisAdvanced && otherAdvanced)
            {
                if (ReferenceEquals(thisValues.Current, null) ^
                    ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null &&
                    !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }

                thisAdvanced = thisValues.MoveNext();
                otherAdvanced = otherValues.MoveNext();
            }
            return !thisAdvanced && !otherAdvanced;
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}