using System;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class RentalByHourTest
    {
        [Test]
        public void HourCalculateCostPrice5Hours1()
        {
            IRental rental = new RentalByHour(5m, 1);

            Assert.AreEqual(5m, rental.CalculateCost());
        }

        [Test]
        public void HourCalculateCostPrice5Hours2()
        {
            IRental rental = new RentalByHour(5m, 2);

            Assert.AreEqual(10m, rental.CalculateCost());
        }

        [Test]
        public void HourCalculateCostPrice5HoursNegative()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByHour(5m, -1); });
        }

        [Test]
        public void HourCalculateCostPrice5HoursZero()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByHour(5m, 0); });
        }

        [Test]
        public void HourCalculateCostPriceNegativeHours10()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByHour(-1m, 10); });
        }

        [Test]
        public void HourCalculateCostPriceZeroHours100()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByHour(0m, 100); });
        }

        [Test]
        public void HourCalculateCostPriceOverflow()
        {
            Assert.Throws<InvalidOperationException>(delegate { new RentalByHour(decimal.MaxValue, int.MaxValue).CalculateCost(); });
        }
    }
}
