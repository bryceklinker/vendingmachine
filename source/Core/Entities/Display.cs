﻿namespace Core.Entities
{
    public interface IDisplay
    {
        string Text { get; }
        void Update(decimal @decimal);
        void Cost(ProductType productType);
        void ThankYou();
        void SoldOut();
    }

    public class Display : IDisplay
    {
        private readonly IInventory _inventory;
        public const string ThankYouText = "THANK YOU";
        public const string InsertCoinText = "INSERT COIN";
        public const string SoldOutText = "SOLD OUT";
        private decimal? _currentValue;
        private decimal? _cost;
        private bool _isThankYou;
        private bool _isSoldOut;

        public string Text
        {
            get { return GetDisplayText(); }
        }
        
        public Display(IInventory inventory)
        {
            _inventory = inventory;
        }

        public void Update(decimal @decimal)
        {
            _currentValue = @decimal;
        }

        public void Cost(ProductType productType)
        {
            _cost = _inventory.GetCost(productType);
        }

        public void ThankYou()
        {
            _isThankYou = true;
        }

        public void SoldOut()
        {
            _isSoldOut = true;
        }

        private string GetDisplayText()
        {
            if (_isSoldOut)
            {
                _isSoldOut = false;
                return SoldOutText;
            }

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
