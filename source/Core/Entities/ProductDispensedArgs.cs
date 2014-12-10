using System;

namespace Core.Entities
{
    public class ProductDispensedArgs : EventArgs
    {
        public ProductType ProductType { get; private set; }

        public ProductDispensedArgs(ProductType productType)
        {
            ProductType = productType;
        }
    }
}
