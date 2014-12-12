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

            var inventory = new Inventory();

            var vendingMachine = new VendingMachine(inventory);
            vendingMachine.CoinReturned += (sender, args) => returnedCoins.Add(args.Coin);
            vendingMachine.ProductDispensed += (sender, args) => dispensedProducts.Add(args.ProductType);

            ScenarioContext.Current.Inventory(inventory);
            ScenarioContext.Current.ReturnedCoins(returnedCoins);
            ScenarioContext.Current.DispensedProducts(dispensedProducts);
            ScenarioContext.Current.VendingMachine(vendingMachine);
        }

        [Given(@"vending machine has (.*) (.*)")]
        public void GivenVendingMachineHasCola(int quantity, ProductType productType)
        {
            var inventory = ScenarioContext.Current.Inventory();
            for (int i = 0; i < quantity; i++)
                inventory.Add(productType);
        }
    }
}
