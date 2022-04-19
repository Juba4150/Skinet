using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Interfaces;
using Core.Entities;
using Inrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Inrastructure.Data
{
    public class ProductRepository:IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            this._context=context;
        }

        public async Task<IList<Product>> GetProducts(){
           return await this._context.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).ToListAsync();
        }
        
        public async Task<Product> GetProduct(int id){
           return await this._context.Products.Include(p=>p.ProductBrand).Include(p=>p.ProductType).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            return await this._context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            return await this._context.ProductTypes.ToListAsync();
        }
    }
}