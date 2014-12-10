using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class AcceptCoinsSteps
    {
        [When(@"I insert (.*)")]
        public void WhenIInsertCoins(string coinString)
        {
            var coins = CoinParser.Parse(coinString);

            var vendingMachine = ScenarioContext.Current.VendingMachine();
            foreach (var coin in coins)
                vendingMachine.Insert(coin);
        }

        [Then(@"the display should say (.*)")]
        public void ThenTheDisplayShouldSay(string display)
        {
            Assert.AreEqual(display, ScenarioContext.Current.VendingMachine().DisplayText);
        }

        [Then(@"(.*) are returned")]
        public void ThenCoinsAreReturned(string coinString)
        {
            var coins = CoinParser.Parse(coinString);
            foreach (var coin in coins)
                Assert.Contains(coin, ScenarioContext.Current.ReturnedCoins());
        }
    }
}
