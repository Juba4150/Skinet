using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace core.Specificatoins
{
    public class ProductsWithBrandsAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecification(ProductParamsSpec productParams)
            : base(p =>
            (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId))
        {
            AddInclued(p => p.ProductBrand);
            AddInclued(p => p.ProductType);
            ApplyPagging(productParams.PageSize*(productParams.PageIndex-1),productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
        }

        public ProductsWithBrandsAndTypesSpecification(int id) : base(p => p.Id == id)
        {
            AddInclued(p => p.ProductBrand);
            AddInclued(p => p.ProductType);
        }
    }
}