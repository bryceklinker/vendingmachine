using System;

namespace Core.Entities
{
    public class ReturnCoinArgs : EventArgs
    {
        public Coin Coin { get; private set; }

        public ReturnCoinArgs(Coin coin)
        {
            Coin = coin;
        }
    }
}
