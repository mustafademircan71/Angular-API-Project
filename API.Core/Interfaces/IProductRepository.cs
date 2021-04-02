using API.Core.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// ID number displays the Sent product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(int id);
        /// <summary>
        /// All Product List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IReadOnlyList<Product>> GetProductAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

    }
}
