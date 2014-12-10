using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
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
            var coins = Parse(coinString);

            var vendingMachine = ScenarioContext.Current.VendingMachine();
            foreach (var coin in coins)
                vendingMachine.Insert(coin);
        }

        [Then(@"the display should say (.*)")]
        public void ThenTheDisplayShouldSay(string display)
        {
            Assert.AreEqual(display, ScenarioContext.Current.VendingMachine().DisplayText);
        }


        private IEnumerable<Coin> Parse(string coinString)
        {
            return coinString.Split(',')
                .Select(s => Enum.Parse(typeof(Coin), s, true))
                .OfType<Coin>();
        }
    }
}
