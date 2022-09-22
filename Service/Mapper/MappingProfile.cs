using AutoMapper;
using Data.Model;
using Dto;

namespace SecondhandSalesApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<OfferDto, Offer>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<SoldDto, Sold>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }

    }
}
