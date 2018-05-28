using System;

namespace Rental
{
    public class RentalByDay : IRental
    {
        private decimal dayCost;
        private int days;

        public RentalByDay(decimal dayCost, int days)
        {
            if (dayCost <= 0m || days <= 0)
                throw new ArgumentException();

            this.dayCost = dayCost;
            this.days = days;
        }

        public decimal CalculateCost()
        {
            decimal retCost = 0m;

            try
            {
                retCost = dayCost * days;
            }
            catch (OverflowException oex)
            {
                throw new InvalidOperationException(oex.Message);
            }

            return retCost;
        }
    }
}
