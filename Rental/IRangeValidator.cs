using System;

namespace Rental
{
    public interface IRangeValidator<T> where T : IComparable, IComparable<T>
    {
        bool Includes(T value);
    }
}
