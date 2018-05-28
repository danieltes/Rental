using System;
using System.Collections.Generic;

namespace Rental
{
    public class RentalContainer : IRental
    {
        private List<IRental> rentals;

        public int RentalsCount
        {
            get
            {
                return rentals.Count;
            }
        }

        public RentalContainer()
        {
            rentals = new List<IRental>();
        }

        public virtual void AddRental(IRental rental)
        {
            if (rental == null)
                throw new ArgumentNullException();

            rentals.Add(rental);
        }

        public virtual decimal CalculateCost()
        {
            decimal retValue = 0m;

            try
            {
                foreach (IRental rental in rentals)
                    retValue += rental.CalculateCost();
            }
            catch (OverflowException oex)
            {
                throw new InvalidOperationException(oex.Message);
            }

            return retValue;
        }
    }
}
