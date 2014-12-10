using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class ReturnCoinsSteps
    {
        [Given(@"I have inserted (.*)")]
        public void GivenIHaveInsertedCoins(string coinString)
        {
            var coins = CoinParser.Parse(coinString);
            foreach (var coin in coins)
                ScenarioContext.Current.VendingMachine().Insert(coin);
        }

        [When(@"I press return coins")]
        public void WhenIPressReturnCoins()
        {
            ScenarioContext.Current.VendingMachine().ReturnCoins();
        }
    }
}
