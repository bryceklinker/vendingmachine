namespace Core.Entities
{
    public interface IVendingMachine
    {
        string DisplayText { get; }
        void Insert(Coin coin);
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
            _balance.Add(coin);
            _display.Update(_balance.CurrentBalance);
        }
    }
}
