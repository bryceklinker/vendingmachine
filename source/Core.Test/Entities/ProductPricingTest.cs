using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class ProductPricingTest
    {
        private ProductPricing _productPricing;

        [SetUp]
        public void Setup()
        {
            _productPricing = new ProductPricing();
        }

        [Test]
        public void ColaShouldBeOneDollar()
        {
            var cost = _productPricing.GetCost(ProductType.Cola);
            Assert.AreEqual(1.00m, cost);
        }

        [Test]
        public void CandyShouldBeSixtyFiveCents()
        {
            var cost = _productPricing.GetCost(ProductType.Candy);
            Assert.AreEqual(0.65m, cost);
        }

        [Test]
        public void ChipsShouldBeFiftyCents()
        {
            var cost = _productPricing.GetCost(ProductType.Chips);
            Assert.AreEqual(0.50m, cost);
        }
    }
}
