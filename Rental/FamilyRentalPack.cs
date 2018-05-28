using System;

namespace Rental
{
    public class FamilyRentalPack : RentalContainer
    {
        private IRangeValidator<int> rangeValidator;
        private IDiscount discount;

        public FamilyRentalPack(IRangeValidator<int> rangeValidator, IDiscount discount) : base()
        {
            if (rangeValidator == null)
                throw new ArgumentNullException("rangeValidator cannot be null");

            if (discount == null)
                throw new ArgumentNullException("discount cannot be null");

            this.rangeValidator = rangeValidator;
            this.discount = discount;
        }

        public override decimal CalculateCost()
        {
            if (!rangeValidator.Includes(RentalsCount))
                throw new InvalidOperationException();

            decimal cost = base.CalculateCost();

            return discount.Apply(cost);
        }
    }
}
