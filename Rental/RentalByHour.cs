using System;

namespace Rental
{
    public class RentalByHour : IRental
    {
        private decimal hourCost;
        private int hours;

        public RentalByHour(decimal hourCost, int hours)
        {
            if (hourCost <= 0m || hours <= 0)
                throw new ArgumentException();

            this.hourCost = hourCost;
            this.hours = hours;
        }

        public decimal CalculateCost()
        {
            decimal retCost = 0m;

            try
            {
                retCost = hourCost * hours;
            }
            catch (OverflowException oex)
            {
                throw new InvalidOperationException(oex.Message);
            }

            return retCost;
        }
    }
}
