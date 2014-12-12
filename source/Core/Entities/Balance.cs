using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public interface IBalance
    {
        decimal CurrentBalance { get; }
        void Add(Coin coin);
        IEnumerable<Coin> Return();
        bool CanPurchase(ProductType cola);
        void Purchase(ProductType chips);
    }

    public class Balance : IBalance
    {
        private readonly IInventory _inventory;
        private readonly List<Coin> _coins; 

        public decimal CurrentBalance
        {
            get { return _coins.Select(c => c.AsValue()).Sum(); }
        }

        public Balance(IInventory inventory)
        {
            _inventory = inventory;
            _coins = new List<Coin>();
        }

        public void Add(Coin coin)
        {
            _coins.Add(coin);
        }

        public IEnumerable<Coin> Return()
        {
            foreach (var coin in _coins)
                yield return coin;

            _coins.Clear();
            
        }

        public bool CanPurchase(ProductType cola)
        {
            return _inventory.GetCost(cola) <= CurrentBalance;
        }

        public void Purchase(ProductType chips)
        {
            _coins.Clear();
        }
    }
}
