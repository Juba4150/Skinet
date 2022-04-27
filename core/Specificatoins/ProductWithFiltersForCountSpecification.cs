using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace core.Specificatoins
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductParamsSpec productParamsSpec) : base(p =>
                    (string.IsNullOrEmpty(productParamsSpec.Search) || p.Name.ToLower().Contains(productParamsSpec.Search)) &&

            (!productParamsSpec.BrandId.HasValue || p.ProductBrandId == productParamsSpec.BrandId) &&
            (!productParamsSpec.TypeId.HasValue || p.ProductTypeId == productParamsSpec.TypeId))
        {

        }
    }
}