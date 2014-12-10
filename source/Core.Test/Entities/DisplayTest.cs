using Core.Entities;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class DisplayTest
    {
        private Display _display;

        [SetUp]
        public void Setup()
        {
            _display = new Display();
        }

        [Test]
        public void TextShouldBeInsertCoin()
        {
            Assert.AreEqual("INSERT COIN", _display.Text);
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
            Assert.AreEqual("INSERT COIN", _display.Text);
        }
    }
}
