using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryStock, CategoryStockDto>().ReverseMap(); 
            CreateMap<ProductsStock, ProductStockDto>().ReverseMap();
            CreateMap<CategoryStock, CategoryStockPayloadDto>().ReverseMap();
        }
    }
}
