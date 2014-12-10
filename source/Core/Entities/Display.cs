namespace Core.Entities
{
    public interface IDisplay
    {
        string Text { get; }
        void Update(decimal @decimal);
        void Cost(ProductType productType);
        void ThankYou();
    }

    public class Display : IDisplay
    {
        private readonly IProductPricing _productPricing;
        public const string ThankYouText = "THANK YOU";
        public const string InsertCoinText = "INSERT COIN";
        private decimal? _currentValue;
        private decimal? _cost;
        private bool _isThankYou;

        public string Text
        {
            get { return GetDisplayText(); }
        }

        public Display()
            : this(new ProductPricing())
        {
            
        }

        public Display(IProductPricing productPricing)
        {
            _productPricing = productPricing;
        }

        public void Update(decimal @decimal)
        {
            _currentValue = @decimal;
        }

        public void Cost(ProductType productType)
        {
            _cost = _productPricing.GetCost(productType);
        }

        public void ThankYou()
        {
            _isThankYou = true;
        }

        private string GetDisplayText()
        {
            if (_isThankYou)
            {
                _isThankYou = false;
                return ThankYouText;
            }

            if (_cost.HasValue)
            {
                var value = _cost.Value;
                _cost = null;
                return value.ToString("c");
            }

            if (!_currentValue.HasValue 
                || _currentValue.Value == 0m)
                return InsertCoinText;

            return _currentValue.Value.ToString("c");
        }
    }
}
