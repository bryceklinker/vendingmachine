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
            var dispensedProducts = new List<ProductType>();

            var vendingMachine = new VendingMachine();
            vendingMachine.CoinReturned += (sender, args) => returnedCoins.Add(args.Coin);
            vendingMachine.ProductDispensed += (sender, args) => dispensedProducts.Add(args.ProductType);

            ScenarioContext.Current.ReturnedCoins(returnedCoins);
            ScenarioContext.Current.DispensedProducts(dispensedProducts);
            ScenarioContext.Current.VendingMachine(vendingMachine);
        }
    }
}
