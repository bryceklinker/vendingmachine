using System.Collections.Generic;
using Core.Entities;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class CommonSteps
    {
        [Given(@"a vending machine")]
        public void GivenAVendingMachine()
        {
            var returnedCoins = new List<Coin>();
            var vendingMachine = new VendingMachine();
            vendingMachine.ReturnCoin += (sender, args) => returnedCoins.Add(args.Coin);

            ScenarioContext.Current.ReturnedCoins(returnedCoins);
            ScenarioContext.Current.VendingMachine(vendingMachine);
        }
    }
}
