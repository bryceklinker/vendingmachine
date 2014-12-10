namespace Core.Entities
{
    public interface IDisplay
    {
        string Text { get; }
        void Update(decimal @decimal);
    }

    public class Display : IDisplay
    {
        private decimal? _currentValue;

        public string Text
        {
            get
            {
                if (_currentValue.GetValueOrDefault(0m) == 0m)
                    return "INSERT COIN";

                return _currentValue.Value.ToString("c");
            }
        }

        public void Update(decimal @decimal)
        {
            _currentValue = @decimal;
        }
    }
}
