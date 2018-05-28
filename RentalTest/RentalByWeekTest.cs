using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class RentalByWeekTest
    {
        [Test]
        public void WeekCalculateCostPrice60Weeks1()
        {
            IRental rental = new RentalByWeek(60m, 1);

            Assert.AreEqual(60m, rental.CalculateCost());
        }

        [Test]
        public void WeekCalculateCostPrice60Weeks2()
        {
            IRental rental = new RentalByWeek(60m, 2);

            Assert.AreEqual(120m, rental.CalculateCost());
        }

        [Test]
        public void WeekCalculateCostPrice60WeeksNegative()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByWeek(60m, -1); });
        }

        [Test]
        public void WeekCalculateCostPrice60WeeksZero()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByWeek(60m, 0); });
        }

        [Test]
        public void WeekCalculateCostPriceNegativeWeeks10()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByWeek(-1m, 10); });
        }

        [Test]
        public void WeekCalculateCostPriceZeroWeeks100()
        {
            Assert.Throws<ArgumentException>(delegate { new RentalByWeek(0m, 100); });
        }

        [Test]
        public void WeekCalculateCostPriceOverflow()
        {
            Assert.Throws<InvalidOperationException>(delegate { new RentalByWeek(decimal.MaxValue, int.MaxValue).CalculateCost(); });
        }
    }
}
