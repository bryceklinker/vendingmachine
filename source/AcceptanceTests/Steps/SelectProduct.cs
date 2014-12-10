using Core.Entities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class SelectProduct
    {
        [When(@"I select (.*)")]
        public void WhenISelectProduct(ProductType productType)
        {
            ScenarioContext.Current.VendingMachine().Purchase(productType);
        }

        [Then(@"the (.*) is dispensed")]
        public void ThenTheProductTypeIsDispensed(ProductType productType)
        {
            Assert.Contains(productType, ScenarioContext.Current.DispensedProducts());
        }

        [Then(@"the product is not dispensed")]
        public void ThenTheProductIsNotDispensed()
        {
            Assert.IsEmpty(ScenarioContext.Current.DispensedProducts());
        }

    }
}
