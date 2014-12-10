using System;

namespace Core.Entities
{
    public interface IVendingMachine
    {
        string DisplayText { get; }
        void Insert(Coin coin);
        void ReturnCoins();
        void Purchase(ProductType productType);
        event EventHandler<ProductDispensedArgs> ProductDispensed;
        event EventHandler<CoinReturnedArgs> CoinReturned;
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

        public void ReturnCoins()
        {
            foreach (var coin in _balance.Return())
                RaiseReturnCoin(coin);

            _display.Update(_balance.CurrentBalance);
        }

        public void Purchase(ProductType productType)
        {
            if (_balance.CanPurchase(productType))
                PurchaseProduct(productType);
            else
                _display.Cost(productType);
        }

        private void PurchaseProduct(ProductType productType)
        {
            _balance.Purchase(productType);
            _display.ThankYou();
            RaiseProductDispensed(productType);
        }

        public event EventHandler<ProductDispensedArgs> ProductDispensed;

        public event EventHandler<CoinReturnedArgs> CoinReturned;

        private void RaiseProductDispensed(ProductType productType)
        {
            if (ProductDispensed != null)
                ProductDispensed(this, new ProductDispensedArgs(productType));
        }

        private void RaiseReturnCoin(Coin coin)
        {
            if (CoinReturned != null)
                CoinReturned(this, new CoinReturnedArgs(coin));
        }
    }
}
