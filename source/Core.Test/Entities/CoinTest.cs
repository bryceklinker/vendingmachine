using System;
using Core.Entities;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class CoinTest
    {
        [Test]
        public void QuarterShouldBeTwentyFiveCents()
        {
            var value = Coin.Quarter.AsValue();
            Assert.AreEqual(0.25m, value);
        }

        [Test]
        public void DimeShouldBeTenCents()
        {
            var value = Coin.Dime.AsValue();
            Assert.AreEqual(0.10m, value);
        }

        [Test]
        public void NickelShouldBeFiveCents()
        {
            var value = Coin.Nickel.AsValue();
            Assert.AreEqual(0.05m, value);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void PennyShouldThrowNotSupported()
        {
            Coin.Penny.AsValue();
        }
    }
}
