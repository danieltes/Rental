using System;
using NUnit.Framework;
using Rental;

namespace RentalTest
{
    [TestFixture]
    public class ClosedRangeValidatorTest
    {
        [Test]
        public void ClosedRangeValidIntegerLowerUpper()
        {
            IRangeValidator<int> range = new ClosedRangeValidator<int>(3, 5);
            Assert.AreEqual(true, range.Includes(4));
        }

        [Test]
        public void ClosedRangeValidIntegerSameLower()
        {
            IRangeValidator<int> range = new ClosedRangeValidator<int>(3, 5);
            Assert.AreEqual(true, range.Includes(3));
        }

        [Test]
        public void ClosedRangeValidIntegerSameUpper()
        {
            IRangeValidator<int> range = new ClosedRangeValidator<int>(3, 5);
            Assert.AreEqual(true, range.Includes(5));
        }

        [Test]
        public void ClosedRangeValidOutsideLessLower()
        {
            IRangeValidator<int> range = new ClosedRangeValidator<int>(3, 5);
            Assert.AreEqual(false, range.Includes(1));
        }

        [Test]
        public void ClosedRangeValidOutsideGreaterUpper()
        {
            IRangeValidator<int> range = new ClosedRangeValidator<int>(3, 5);
            Assert.AreEqual(false, range.Includes(6));
        }

        [Test]
        public void RangeValidIntegerMinimumGreaterThanMaximum()
        {
            Assert.Throws<ArgumentException>(delegate { new ClosedRangeValidator<int>(5, 3); });
        }

        [Test]
        public void RangeValidIntegerMinimumEqualMaximum()
        {
            Assert.Throws<ArgumentException>(delegate { new ClosedRangeValidator<int>(5, 5); });
        }
    }
}
