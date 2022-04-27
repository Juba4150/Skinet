using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace core.Specificatoins
{
    public class ProductsWithBrandsAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandsAndTypesSpecification(ProductParamsSpec productParamsSpec)
            : base(p =>
            (string.IsNullOrEmpty(productParamsSpec.Search) || p.Name.ToLower().Contains(productParamsSpec.Search)) &&
            (!productParamsSpec.BrandId.HasValue || p.ProductBrandId == productParamsSpec.BrandId) &&
            (!productParamsSpec.TypeId.HasValue || p.ProductTypeId == productParamsSpec.TypeId))
        {
            AddInclued(p => p.ProductBrand);
            AddInclued(p => p.ProductType);
            ApplyPagging(productParamsSpec.PageSize * (productParamsSpec.PageIndex - 1), productParamsSpec.PageSize);
            if (!string.IsNullOrEmpty(productParamsSpec.Sort))
                switch (productParamsSpec.Sort)
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