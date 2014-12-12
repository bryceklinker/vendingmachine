using Core.Entities;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory _inventory;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
        }

        [Test]
        public void AddShouldAddToChipsQuantity()
        {
            _inventory.Add(ProductType.Chips);
            var quantity = _inventory.GetAvailableQuantity(ProductType.Chips);
            Assert.AreEqual(1, quantity);
        }

        [Test]
        public void AddShouldAddToCandyQuantity()
        {
            _inventory.Add(ProductType.Candy);
            var quantity = _inventory.GetAvailableQuantity(ProductType.Candy);
            Assert.AreEqual(1, quantity);
        }

        [Test]
        public void AddShouldAddToColaQuantity()
        {
            _inventory.Add(ProductType.Cola);
            var quantity = _inventory.GetAvailableQuantity(ProductType.Cola);
            Assert.AreEqual(1, quantity);
        }

        [Test]
        public void RemoveShouldRemoveFromChipsQuantity()
        {
            _inventory.Add(ProductType.Chips);
            _inventory.Remove(ProductType.Chips);
            var quantity = _inventory.GetAvailableQuantity(ProductType.Chips);
            Assert.AreEqual(0, quantity);
        }

        [Test]
        public void RemoveShouldRemoveFromCandyQuantity()
        {
            _inventory.Add(ProductType.Candy);
            _inventory.Remove(ProductType.Candy);
            var quantity = _inventory.GetAvailableQuantity(ProductType.Candy);
            Assert.AreEqual(0, quantity);
        }

        [Test]
        public void RemoveShouldRemoveFromColaQuantity()
        {
            _inventory.Add(ProductType.Cola);
            _inventory.Remove(ProductType.Cola);
            var quantity = _inventory.GetAvailableQuantity(ProductType.Cola);
            Assert.AreEqual(0, quantity);
        }

        [Test]
        public void ColaShouldBeOneDollar()
        {
            var cost = _inventory.GetCost(ProductType.Cola);
            Assert.AreEqual(1.00m, cost);
        }

        [Test]
        public void CandyShouldBeSixtyFiveCents()
        {
            var cost = _inventory.GetCost(ProductType.Candy);
            Assert.AreEqual(0.65m, cost);
        }

        [Test]
        public void ChipsShouldBeFiftyCents()
        {
            var cost = _inventory.GetCost(ProductType.Chips);
            Assert.AreEqual(0.50m, cost);
        }

        [Test]
        public void IsSoldoutShouldBeTrue()
        {
            var isSoldOut = _inventory.IsSoldOut(ProductType.Candy);
            Assert.IsTrue(isSoldOut);
        }

        [Test]
        public void IsSoldOutShouldBeFalse()
        {
            _inventory.Add(ProductType.Cola);
            var isSoldOut = _inventory.IsSoldOut(ProductType.Cola);
            Assert.IsFalse(isSoldOut);
        }
    }
}
