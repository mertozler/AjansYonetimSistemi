using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace Project.MapperProfiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerProducts, CustomerProductDetailForCustomerDTO>()
                .ForMember(dest => dest.ProductTitle, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.ProductContent, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.ProductDate, opt => opt.MapFrom(src => src.CreateDate))
                .ForMember(dest => dest.CustomerProductsID, opt => opt.MapFrom(src => src.id));
        }
    }
}