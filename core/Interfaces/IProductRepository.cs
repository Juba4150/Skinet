using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace core.Interfaces
{
    public interface IProductRepository
    {
        public Task<IList<Product>> GetProducts();
        public Task<Product> GetProduct(int id);
        public Task<IReadOnlyList<ProductBrand>> GetProductBrands ();
        public Task<IReadOnlyList<ProductType>> GetProductTypes ();
    }
}