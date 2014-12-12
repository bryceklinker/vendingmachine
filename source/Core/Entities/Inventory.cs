using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public interface IInventory
    {
        void Add(ProductType productType);
        int GetAvailableQuantity(ProductType productType);
        bool IsSoldOut(ProductType productType);
        void Remove(ProductType productType);
        decimal GetCost(ProductType productType);
    }

    public class Inventory : IInventory
    {
        private readonly Dictionary<ProductType, int> _inventory;

        public Inventory()
        {
            _inventory = Enum.GetValues(typeof(ProductType))
                .Cast<ProductType>()
                .ToDictionary(p => p, p => 0);
        }

        public void Add(ProductType productType)
        {
            _inventory[productType]++;
        }

        public int GetAvailableQuantity(ProductType productType)
        {
            return _inventory[productType];
        }

        public bool IsSoldOut(ProductType productType)
        {
            return GetAvailableQuantity(productType) <= 0;
        }

        public void Remove(ProductType productType)
        {
            _inventory[productType]--;
        }

        public decimal GetCost(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Cola:
                    return 1.00m;
                case ProductType.Chips:
                    return 0.50m;
                case ProductType.Candy:
                    return 0.65m;
                default:
                    throw new ArgumentOutOfRangeException("productType");
            }
        }
    }
}
