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
            ScenarioContext.Current.VendingMachine(new VendingMachine());
        }
    }
}
