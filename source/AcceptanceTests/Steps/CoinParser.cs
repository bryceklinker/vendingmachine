using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace AcceptanceTests.Steps
{
    public static class CoinParser
    {
        public static IEnumerable<Coin> Parse(string coinString)
        {
            return coinString.Split(',')
                .Select(s => Enum.Parse(typeof(Coin), s, true))
                .OfType<Coin>();
        }
    }
}
