using System.Collections.Generic;
using System.Linq;

namespace FastRecipe.Domain.SeedWork
{
    public abstract class ValueObject
    {
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) != ReferenceEquals(right, null))
                return false;
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
            => !(left == right);

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || (obj is ValueObject) == false)
                return false;

            var other = (ValueObject)obj;
            var thisValues = GetAtomicValues().GetEnumerator();
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) !=
                    ReferenceEquals(otherValues.Current, null))
                    return false;

                if (thisValues.Current != null &&
                    thisValues.Current.Equals(otherValues.Current) == false)
                    return false;
            }

            return thisValues.MoveNext() == false && otherValues.MoveNext() == false;
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                        .Select(a => a != null ? a.GetHashCode() : 0)
                        .Aggregate((x, y) => x ^ y);
        }
    }
}
