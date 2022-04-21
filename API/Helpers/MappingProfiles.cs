using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturn>()
                .ForMember(pd => pd.ProductBrand, m => m.MapFrom(s => s.ProductBrand.Name))
                .ForMember(pd => pd.ProductType, m => m.MapFrom(s => s.ProductType.Name))
                .ForMember(pd=>pd.PictureUrl,m=>m.MapFrom<ProductUrlResolver>());
        }
    }
}