using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Spesicifications
{
    public class ProductsWithFiltersForCountSpesification:BaseSpesification<Product>
    {
        public ProductsWithFiltersForCountSpesification(ProductSpecParams productSpecParams)
             : base(x =>
                     (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                     &&
                     (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId)
                 )
        {

        }
    }
}
