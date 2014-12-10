using Core.Entities;
using Moq;
using NUnit.Framework;

namespace Core.Test.Entities
{
    [TestFixture]
    public class VendingMachineTest
    {
        private Mock<IDisplay> _displayMock;
        private Mock<IBalance> _balanceMock;
        private VendingMachine _vendingMachine;

        [SetUp]
        public void Setup()
        {
            _displayMock = new Mock<IDisplay>();
            _balanceMock = new Mock<IBalance>();
            _vendingMachine = new VendingMachine(_displayMock.Object, _balanceMock.Object);
        }

        [Test]
        public void DisplayTextShouldGetTextFromDisplay()
        {
            _displayMock.Setup(s => s.Text).Returns("Display");

            Assert.AreEqual("Display", _vendingMachine.DisplayText);
        }

        [Test]
        public void InsertShouldAddCoin()
        {
            _vendingMachine.Insert(Coin.Quarter);
            _balanceMock.Verify(s => s.Add(Coin.Quarter), Times.Once());
        }

        [Test]
        public void InsertShouldUpdateDisplay()
        {
            _balanceMock.Setup(s => s.CurrentBalance).Returns(0.25m);

            _vendingMachine.Insert(Coin.Quarter);
            _displayMock.Verify(s => s.Update(0.25m), Times.Once());
        }
    }
}
