using System;

namespace Core.Entities
{
    public interface IVendingMachine
    {
        string DisplayText { get; }
        void Insert(Coin coin);
        event EventHandler<ReturnCoinArgs> ReturnCoin;
    }

    public class VendingMachine : IVendingMachine
    {
        private readonly IDisplay _display;
        private readonly IBalance _balance;

        public string DisplayText
        {
            get { return _display.Text; }
        }

        public VendingMachine()
            : this(new Display(), new Balance())
        {
            
        }

        public VendingMachine(IDisplay display, IBalance balance)
        {
            _display = display;
            _balance = balance;
        }

        public void Insert(Coin coin)
        {
            if (coin == Coin.Penny)
                RaiseReturnCoin(coin);
            else
                AddCoin(coin);
        }

        private void AddCoin(Coin coin)
        {
            _balance.Add(coin);
            _display.Update(_balance.CurrentBalance);
        }

        public event EventHandler<ReturnCoinArgs> ReturnCoin;

        private void RaiseReturnCoin(Coin coin)
        {
            if (ReturnCoin != null)
                ReturnCoin(this, new ReturnCoinArgs(coin));
        }
    }
}
