using System;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class RentalByDayTest
    {
        [Test]
        public void DayCalculateCostPrice20Days1()
        {
            IRental rental = new RentalByDay(20m, 1);

            Assert.AreEqual(20m, rental.CalculateCost());
        }

        [Test]
        public void DayCalculateCostPrice20Days2()
        {
            IRental rental = new RentalByDay(20m, 2);

            Assert.AreEqual(40m, rental.CalculateCost());
        }

        [Test]
        public void DayCalculateCostPrice20DaysNegative()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByDay(20m, -1); });
        }

        [Test]
        public void DayCalculateCostPrice20DaysZero()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByDay(20m, 0); });
        }

        [Test]
        public void DayCalculateCostPriceNegativeDays10()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByDay(-1m, 10); });
        }

        [Test]
        public void DayCalculateCostPriceZeroDays100()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByDay(0m, 100); });
        }

        [Test]
        public void DayCalculateCostPriceOverflow()
        {
            Assert.Throws<InvalidOperationException>(delegate { new RentalByDay(decimal.MaxValue, int.MaxValue).CalculateCost(); });
        }
    }
}
