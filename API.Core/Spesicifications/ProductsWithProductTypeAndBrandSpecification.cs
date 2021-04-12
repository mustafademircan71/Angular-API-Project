using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace API.Core.Spesicifications
{
    public class ProductsWithProductTypeAndBrandSpecification:BaseSpesification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification(ProductSpecParams productSpecParams)
            :base(x=>
                    (string.IsNullOrWhiteSpace(productSpecParams.Search)||x.Name.ToLower().Contains(productSpecParams.Search))
                    &&
                    (!productSpecParams.BrandId.HasValue||x.ProductBrandId==productSpecParams.BrandId)
                    &&
                    (!productSpecParams.TypeId.HasValue||x.ProductTypeId==productSpecParams.TypeId)
                 )
        {
            AddInlcude(x => x.ProductBrand);
            AddInlcude(x => x.ProductType);
            //AddOrderBy(x => x.Name);
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1),productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                       
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
           
        }
        public ProductsWithProductTypeAndBrandSpecification(int id)
            :base(x=>x.Id==id)
        {
            AddInlcude(x => x.ProductBrand);
            AddInlcude(x => x.ProductType);
        }
    }
}
