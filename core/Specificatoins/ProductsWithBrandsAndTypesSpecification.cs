using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace core.Specificatoins
{
    public class ProductsWithBrandsAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecification()
        {
            AddInclued(p => p.ProductBrand);
            AddInclued(p => p.ProductType);
        }

        public ProductsWithBrandsAndTypesSpecification(int id) : base(p => p.Id == id)
        {
            AddInclued(p => p.ProductBrand);
            AddInclued(p => p.ProductType);
        }
    }
}