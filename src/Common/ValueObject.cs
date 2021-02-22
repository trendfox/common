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
        /// <summary>
        /// Checks if two <see cref="ValueObject"/> are equal in value.
        /// </summary>
        /// <param name="left">Left object to compare.</param>
        /// <param name="right">Right object to compare.</param>
        /// <returns>True, if the value is the same.</returns>
        protected static bool EqualOperator(ValueObject? left, ValueObject? right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right!);
        }

        /// <summary>
        /// Checks if two <see cref="ValueObject"/> are not equal in value.
        /// </summary>
        /// <param name="left">Left object to compare.</param>
        /// <param name="right">Right object to compare.</param>
        /// <returns>True, if the value is not the same.</returns>
        protected static bool NotEqualOperator(ValueObject? left, ValueObject? right)
        {
            return !(EqualOperator(left, right));
        }

        /// <summary>
        /// Checks if two <see cref="ValueObject"/> are equal in value.
        /// </summary>
        /// <param name="left">Left object to compare.</param>
        /// <param name="right">Right object to compare.</param>
        /// <returns>True, if the value is the same.</returns>
        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            return EqualOperator(left, right);
        }


        /// <summary>
        /// Checks if two <see cref="ValueObject"/> are not equal in value.
        /// </summary>
        /// <param name="left">Left object to compare.</param>
        /// <param name="right">Right object to compare.</param>
        /// <returns>True, if the value is not the same.</returns>
        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return NotEqualOperator(left, right);
        }

        /// <summary>
        /// Return all atomic values for this value object instance. 
        /// </summary>
        /// <returns>All atomic values making up this value object.</returns>
        protected abstract IEnumerable<object?> GetAtomicValues();

        /// <summary>
        /// Check if this instances is equal to another instance.
        /// </summary>
        /// <param name="obj">Other instance.</param>
        /// <returns>True, if the value objects are equal.</returns>
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

        /// <summary>
        /// Returns the hash code for this instance. Two instances
        /// with the same values result in the same hash code.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}