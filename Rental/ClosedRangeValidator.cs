using System;

namespace Rental
{
    public class ClosedRangeValidator<T> : IRangeValidator<T> where T : IComparable, IComparable<T>
    {
        private T lowerBound;
        private T upperBound;

        public ClosedRangeValidator(T lowerBound, T upperBound)
        {
            if (lowerBound.CompareTo(upperBound) == 0 || lowerBound.CompareTo(upperBound) > 0)
                throw new ArgumentException();

            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }

        public bool Includes(T value)
        {
            return ((value.CompareTo(lowerBound) == 0 || value.CompareTo(lowerBound) > 0) && 
                (value.CompareTo(upperBound) == 0 || value.CompareTo(upperBound) < 0));
        }
    }
}
