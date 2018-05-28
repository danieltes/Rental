using System;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class FamilyRentalPackTest
    {
        [Test]
        public void FamilyRentalCalculate1Hour1Day1Week()
        {
            FamilyRentalPack family = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));

            family.AddRental(new RentalByHour(5m, 1));
            family.AddRental(new RentalByDay(20m, 1));
            family.AddRental(new RentalByWeek(60m, 1));

            Assert.AreEqual(59.5m, family.CalculateCost());
        }

        [Test]
        public void FamilyRentalCalculate2Hours2Days1Week()
        {
            FamilyRentalPack family = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));

            family.AddRental(new RentalByHour(5m, 1));
            family.AddRental(new RentalByHour(5m, 2));
            family.AddRental(new RentalByDay(20m, 1));
            family.AddRental(new RentalByDay(20m, 2));
            family.AddRental(new RentalByWeek(60m, 3));

            Assert.AreEqual(178.5m, family.CalculateCost());
        }

        [Test]
        public void FamilyRentalCalculate1Hour1Day1Family()
        {
            FamilyRentalPack family = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));
            family.AddRental(new RentalByHour(5m, 1));
            family.AddRental(new RentalByHour(5m, 2));
            family.AddRental(new RentalByDay(20m, 1));
            family.AddRental(new RentalByDay(20m, 2));
            family.AddRental(new RentalByWeek(60m, 3));

            FamilyRentalPack mainFamily = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));
            mainFamily.AddRental(family);
            mainFamily.AddRental(new RentalByHour(5m, 1));
            mainFamily.AddRental(new RentalByDay(20m, 1));

            Assert.AreEqual(142.45m, mainFamily.CalculateCost());
        }

        [Test]
        public void FamilyRentalCalculateLessThan3()
        {
            FamilyRentalPack family = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));

            family.AddRental(new RentalByHour(5m, 1));
            family.AddRental(new RentalByHour(5m, 2));

            Assert.Throws<InvalidOperationException>(delegate { family.CalculateCost(); });
        }

        [Test]
        public void FamilyRentalCalculateMoreThan5()
        {
            FamilyRentalPack family = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));

            family.AddRental(new RentalByHour(5m, 1));
            family.AddRental(new RentalByHour(5m, 2));
            family.AddRental(new RentalByDay(20m, 1));
            family.AddRental(new RentalByDay(20m, 2));
            family.AddRental(new RentalByWeek(60m, 3));
            family.AddRental(new RentalByWeek(60m, 4));

            Assert.Throws<InvalidOperationException>(delegate { family.CalculateCost(); });
        }

        [Test]
        public void FamilyRentalWithOverflow()
        {
            FamilyRentalPack family = new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), new StandardDiscount(30m));

            family.AddRental(new RentalByHour(decimal.MaxValue, int.MaxValue));
            family.AddRental(new RentalByDay(20m, 1));
            family.AddRental(new RentalByWeek(60m, 1));

            Assert.Throws<InvalidOperationException>(delegate { family.CalculateCost(); });
        }

        [Test]
        public void FamilyRentalCalculateNoDiscount()
        {
            Assert.Throws<ArgumentNullException>(delegate { new FamilyRentalPack(new ClosedRangeValidator<int>(3, 5), null); });
        }

        [Test]
        public void FamilyRentalCalculateNoRange()
        {
            Assert.Throws<ArgumentNullException>(delegate { new FamilyRentalPack(null, new StandardDiscount(30m)); });
        }
    }
}
