using System.Linq;
using Core.Entities;
using Moq;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class BalanceTest
    {
        private Balance _balance;
        private Mock<IInventory> _inventoryMock;

        [SetUp]
        public void Setup()
        {
            _inventoryMock = new Mock<IInventory>();
            _balance = new Balance(_inventoryMock.Object);
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

        [Test]
        public void CanPurchaseShouldBeTrue()
        {
            _balance.Add(Coin.Quarter);
            _balance.Add(Coin.Quarter);
            _inventoryMock.Setup(s => s.GetCost(ProductType.Cola)).Returns(0.50m);

            var canPurchase = _balance.CanPurchase(ProductType.Cola);
            Assert.IsTrue(canPurchase);
        }

        [Test]
        public void CanPurchaseShouldBeTrueIfBalanceGreaterThanCost()
        {
            _balance.Add(Coin.Quarter);
            _inventoryMock.Setup(s => s.GetCost(ProductType.Chips)).Returns(0.05m);

            var canPurchase = _balance.CanPurchase(ProductType.Chips);
            Assert.IsTrue(canPurchase);
        }

        [Test]
        public void CanPurchaseShouldBeFalse()
        {
            _balance.Add(Coin.Quarter);
            _inventoryMock.Setup(s => s.GetCost(ProductType.Chips)).Returns(0.75m);

            var canPurchase = _balance.CanPurchase(ProductType.Chips);
            Assert.IsFalse(canPurchase);
        }

        [Test]
        public void PurchaseShouldReduceBalance()
        {
            _balance.Add(Coin.Quarter);
            _balance.Add(Coin.Quarter);
            _inventoryMock.Setup(s => s.GetCost(ProductType.Cola)).Returns(0.45m);

            _balance.Purchase(ProductType.Cola);
            Assert.AreEqual(0.0m, _balance.CurrentBalance);
        }
    }
}
