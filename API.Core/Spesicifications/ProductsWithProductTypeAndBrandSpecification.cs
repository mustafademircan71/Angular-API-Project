using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Spesicifications
{
    public class ProductsWithProductTypeAndBrandSpecification:BaseSpesification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification()
        {
            AddInlcude(x => x.ProductBrand);
            AddInlcude(x => x.ProductType);
        }
        public ProductsWithProductTypeAndBrandSpecification(int id)
            :base(x=>x.Id==id)
        {
            AddInlcude(x => x.ProductBrand);
            AddInlcude(x => x.ProductType);
        }
    }
}
