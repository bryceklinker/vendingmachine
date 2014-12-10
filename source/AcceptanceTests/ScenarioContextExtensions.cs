using Core.Entities;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    public static class ScenarioContextExtensions
    {
        private const string VendingMachineKey = "VendingMachine";

        public static IVendingMachine VendingMachine(this ScenarioContext scenarioContext)
        {
            return scenarioContext.SafeGet<IVendingMachine>(VendingMachineKey);
        }

        public static void VendingMachine(this ScenarioContext scenarioContext, IVendingMachine vendingMachine)
        {
            scenarioContext.Set(vendingMachine, VendingMachineKey);
        }

        private static T SafeGet<T>(this ScenarioContext scenarioContext, string key)
        {
            return scenarioContext.ContainsKey(key) 
                ? scenarioContext.Get<T>(key)
                : default(T);
        }
    }
}
