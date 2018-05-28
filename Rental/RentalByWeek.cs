using System;

namespace Rental
{
    public class RentalByWeek : IRental
    {
        private decimal weekCost;
        private int weeks;

        public RentalByWeek(decimal weekCost, int weeks)
        {
            if (weekCost <= 0m || weeks <= 0)
                throw new ArgumentException();

            this.weekCost = weekCost;
            this.weeks = weeks;
        }

        public decimal CalculateCost()
        {
            decimal retCost = 0m;

            try
            {
                retCost = weekCost * weeks;
            }
            catch (OverflowException oex)
            {
                throw new InvalidOperationException(oex.Message);
            }

            return retCost; 
        }
    }
}
