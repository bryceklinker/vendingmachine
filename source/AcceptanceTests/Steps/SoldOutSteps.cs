using Core.Entities;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class SoldOutSteps
    {
        [Given(@"(.*) is sold out")]
        public void GivenProductIsSoldOut(ProductType productType)
        {
            var inventory = ScenarioContext.Current.Inventory();
            var availableQuantity = inventory.GetAvailableQuantity(productType);
            for (var i = 0; i < availableQuantity; i++)
                inventory.Remove(productType);
        }
    }
}
