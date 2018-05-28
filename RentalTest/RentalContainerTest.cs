using System;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class RentalContainerTest
    {
        [Test]
        public void ContainerCalculate2Hours2Days2Weeks()
        {
            RentalContainer rentalContainer = new RentalContainer();

            rentalContainer.AddRental(new RentalByHour(5m, 3));
            rentalContainer.AddRental(new RentalByHour(5m, 5));
            rentalContainer.AddRental(new RentalByDay(20m, 30));
            rentalContainer.AddRental(new RentalByDay(20m, 50));
            rentalContainer.AddRental(new RentalByWeek(60m, 300));
            rentalContainer.AddRental(new RentalByWeek(60m, 500));

            Assert.AreEqual(49640m, rentalContainer.CalculateCost());
        }

        [Test]
        public void ContainerCalculateWithoutRentals()
        {
            RentalContainer rentalContainer = new RentalContainer();
            Assert.AreEqual(0, rentalContainer.CalculateCost());
        }

        [Test]
        public void ContainerCalculateWithNullRental()
        {
            RentalContainer rentalContainer = new RentalContainer();

            Assert.Throws<ArgumentNullException>(delegate { rentalContainer.AddRental(null); });
        }

        [Test]
        public void ContainerCalculateWithOverflowRental()
        {
            RentalContainer rentalContainer = new RentalContainer();
            rentalContainer.AddRental(new RentalByDay(decimal.MaxValue, int.MaxValue));

            Assert.Throws<InvalidOperationException>(delegate { rentalContainer.CalculateCost(); });
        }

        [Test]
        public void ContainerCalculateWithOverflowUsingTwoRentals()
        {
            RentalContainer rentalContainer = new RentalContainer();
            rentalContainer.AddRental(new RentalByDay(decimal.MaxValue, 1));
            rentalContainer.AddRental(new RentalByWeek(decimal.MaxValue, 1));

            Assert.Throws<InvalidOperationException>(delegate { rentalContainer.CalculateCost(); });
        }

        [Test]
        public void ContainerCalculateWithContainer()
        {
            RentalContainer mainContainer = new RentalContainer();

            RentalContainer rentalContainer = new RentalContainer();
            rentalContainer.AddRental(new RentalByHour(5m, 3));
            rentalContainer.AddRental(new RentalByDay(20m, 30));
            rentalContainer.AddRental(new RentalByWeek(60m, 300));

            mainContainer.AddRental(rentalContainer);
            mainContainer.AddRental(new RentalByWeek(60m, 2));

            Assert.AreEqual(18735, mainContainer.CalculateCost());
        }
    }
}
