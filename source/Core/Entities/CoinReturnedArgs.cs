using System;

namespace Core.Entities
{
    public class CoinReturnedArgs : EventArgs
    {
        public Coin Coin { get; private set; }

        public CoinReturnedArgs(Coin coin)
        {
            Coin = coin;
        }
    }
}
