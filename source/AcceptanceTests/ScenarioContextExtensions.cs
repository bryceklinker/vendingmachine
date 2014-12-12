using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Core.Entities;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    public static class ScenarioContextExtensions
    {
        private const string ReturnedCoinsKey = "ReturnedCoins";
        private const string DispensedProductsKey = "DispensedProducts";
        private const string VendingMachineKey = "VendingMachine";
        private const string InventoryKey = "Inventory";

        public static IVendingMachine VendingMachine(this ScenarioContext scenarioContext)
        {
            return scenarioContext.SafeGet<IVendingMachine>(VendingMachineKey);
        }

        public static void VendingMachine(this ScenarioContext scenarioContext, IVendingMachine vendingMachine)
        {
            scenarioContext.Set(vendingMachine, VendingMachineKey);
        }

        public static List<Coin> ReturnedCoins(this ScenarioContext scenarioContext)
        {
            return scenarioContext.SafeGet<List<Coin>>(ReturnedCoinsKey);
        }

        public static void ReturnedCoins(this ScenarioContext scenarioContext, List<Coin> coins)
        {
            scenarioContext.Set(coins, ReturnedCoinsKey);
        }

        public static List<ProductType> DispensedProducts(this ScenarioContext scenarioContext)
        {
            return scenarioContext.SafeGet<List<ProductType>>(DispensedProductsKey);
        }

        public static void DispensedProducts(this ScenarioContext scenarioContext, List<ProductType> dispensedProductTypes)
        {
            scenarioContext.Set(dispensedProductTypes, DispensedProductsKey);
        }

        public static IInventory Inventory(this ScenarioContext scenarioContext)
        {
            return scenarioContext.SafeGet<IInventory>(InventoryKey);
        }

        public static void Inventory(this ScenarioContext scenarioContext, IInventory inventory)
        {
            scenarioContext.Set(inventory, InventoryKey);
        }

        private static T SafeGet<T>(this ScenarioContext scenarioContext, string key)
        {
            return scenarioContext.ContainsKey(key) 
                ? scenarioContext.Get<T>(key)
                : default(T);
        }
    }
}
