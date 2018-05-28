using System;

namespace Rental
{
    public class StandardDiscount : IDiscount
    {
        private decimal discountPercentage;

        public StandardDiscount(decimal discountPercentage)
        {
            if (discountPercentage <= 0 || discountPercentage > 100)
                throw new ArgumentException();

            this.discountPercentage = discountPercentage;
        }

        public decimal Apply(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException();

            return value * (1 - (discountPercentage / 100));
        }
    }
}
