using System.Linq;
using Core.Entities;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class BalanceTest
    {
        private Balance _balance;

        [SetUp]
        public void Setup()
        {
            _balance = new Balance();
        }

        [Test]
        public void AddShouldUpdateBalanceWithCoinValue()
        {
            _balance.Add(Coin.Quarter);
            Assert.AreEqual(0.25m, _balance.CurrentBalance);
        }

        [Test]
        public void AddShouldAccumulateCoinValues()
        {
            _balance.Add(Coin.Quarter);
            _balance.Add(Coin.Dime);
            _balance.Add(Coin.Nickel);
            Assert.AreEqual(0.40m, _balance.CurrentBalance);
        }

        [Test]
        public void ReturnShouldReturnAddedCoins()
        {
            _balance.Add(Coin.Quarter);
            _balance.Add(Coin.Nickel);
            _balance.Add(Coin.Dime);

            var coins = _balance.Return().ToList();
            Assert.Contains(Coin.Quarter, coins);
            Assert.Contains(Coin.Dime, coins);
            Assert.Contains(Coin.Nickel, coins);
        }

        [Test]
        public void ReturnShouldBeEmpty()
        {
            _balance.Add(Coin.Quarter);

            _balance.Return().ToList();
            var secondReturn = _balance.Return().ToList();
            Assert.IsEmpty(secondReturn);
        }

        [Test]
        public void ReturnShouldResetCurrentBalance()
        {
            _balance.Add(Coin.Quarter);

            _balance.Return().ToList();
            Assert.AreEqual(0.0m, _balance.CurrentBalance);
        }
    }
}
