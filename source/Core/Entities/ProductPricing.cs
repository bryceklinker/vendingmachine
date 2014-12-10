using System;

namespace Core.Entities
{
    public interface IProductPricing
    {
        decimal GetCost(ProductType productType);
    }

    public class ProductPricing : IProductPricing
    {
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
