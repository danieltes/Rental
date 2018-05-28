using System;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class StandardDiscountTest
    {
        [Test]
        public void FamilyApply30PerTo100()
        {
            IDiscount discount = new StandardDiscount(30m);

            Assert.AreEqual(70m, discount.Apply(100m));
        }

        [Test]
        public void FamilyApply30PerTo0()
        {
            IDiscount discount = new StandardDiscount(30m);

            Assert.Throws<ArgumentException>(delegate { discount.Apply(0m);  });
        }

        [Test]
        public void FamilyApply30PerToNegative()
        {
            IDiscount discount = new StandardDiscount(30m);

            Assert.Throws<ArgumentException>(delegate { discount.Apply(-10000m); });
        }

        [Test]
        public void FamilyApplyNegativeDiscount()
        {
            Assert.Throws<ArgumentException>(delegate { new StandardDiscount(-30m); });
        }

        [Test]
        public void FamilyApplyZeroDiscount()
        {
            Assert.Throws<ArgumentException>(delegate { new StandardDiscount(0m); });
        }

        [Test]
        public void FamilyApplyMoreThan100Discount()
        {
            Assert.Throws<ArgumentException>(delegate { new StandardDiscount(110m); });
        }
    }
}
