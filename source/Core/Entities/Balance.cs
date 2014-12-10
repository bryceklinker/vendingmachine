namespace Core.Entities
{
    public interface IBalance
    {
        void Add(Coin coin);
        decimal CurrentBalance { get; }
    }

    public class Balance : IBalance
    {
        private decimal _currentBalance;

        public Balance()
        {
            _currentBalance = 0.0m;
        }

        public void Add(Coin coin)
        {
            _currentBalance += coin.AsValue();
        }

        public decimal CurrentBalance
        {
            get { return _currentBalance; }
        }
    }
}
