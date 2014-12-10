using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public interface IBalance
    {
        decimal CurrentBalance { get; }
        void Add(Coin coin);
        IEnumerable<Coin> Return();
    }

    public class Balance : IBalance
    {
        private readonly List<Coin> _coins; 

        public decimal CurrentBalance
        {
            get { return _coins.Select(c => c.AsValue()).Sum(); }
        }

        public Balance()
        {
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
    }
}
