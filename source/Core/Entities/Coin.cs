using System;

namespace Core.Entities
{
    public static class CoinExtensions
    {
        public static decimal AsValue(this Coin coin)
        {
            switch (coin)
            {
                case Coin.Quarter:
                    return 0.25m;
                case Coin.Dime:
                    return 0.10m;
                case Coin.Nickel:
                    return 0.05m;
                default:
                    throw new NotSupportedException();
            }
        }
    }

    public enum Coin
    {
        Quarter,
        Dime,
        Nickel,
        Penny
    }
}
