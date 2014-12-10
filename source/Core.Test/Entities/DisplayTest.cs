using Core.Entities;
using Moq;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class DisplayTest
    {
        private Display _display;
        private Mock<IProductPricing> _productPricingMock;

        [SetUp]
        public void Setup()
        {
            _productPricingMock = new Mock<IProductPricing>();
            _display = new Display(_productPricingMock.Object);
        }

        [Test]
        public void TextShouldBeInsertCoin()
        {
            Assert.AreEqual(Display.InsertCoinText, _display.Text);
        }

        [Test]
        public void UpdateShouldUpdateTextToBalance()
        {
            _display.Update(0.45m);
            Assert.AreEqual("$0.45", _display.Text);
        }

        [Test]
        public void UpdateWithZeroShouldChangeTextToInsertCoin()
        {
            _display.Update(0.45m);
            _display.Update(0.0m);
            Assert.AreEqual(Display.InsertCoinText, _display.Text);
        }

        [Test]
        public void CostShouldUpdateTextToCostOfProduct()
        {
            const ProductType productType = ProductType.Chips;
            const decimal cost = 3.4m;
            _productPricingMock.Setup(s => s.GetCost(productType)).Returns(cost);

            _display.Cost(productType);
            Assert.AreEqual(cost.ToString("c"), _display.Text);
        }

        [Test]
        public void CostShouldUpdateTextToBalance()
        {
            const ProductType productType = ProductType.Chips;
            const decimal cost = 1.4m;
            _productPricingMock.Setup(s => s.GetCost(productType)).Returns(cost);

            _display.Update(4.5m);
            _display.Cost(productType);
            Assert.AreEqual(cost.ToString("c"), _display.Text);
            Assert.AreEqual("$4.50", _display.Text);
        }

        [Test]
        public void ThankYouShouldUpdateTextToThankYou()
        {
            _display.ThankYou();
            Assert.AreEqual(Display.ThankYouText, _display.Text);
        }

        [Test]
        public void ThankYouShouldUpdateTextToInsertCoin()
        {
            _display.ThankYou();
            Assert.AreEqual(Display.ThankYouText, _display.Text);
            Assert.AreEqual(Display.InsertCoinText, _display.Text);
        }
    }
}
