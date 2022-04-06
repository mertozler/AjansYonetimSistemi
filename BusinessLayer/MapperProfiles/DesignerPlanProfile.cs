using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace Project.MapperProfiles
{
    public class DesignerPlanProfile : Profile
    {
        public DesignerPlanProfile()
        {
            CreateMap<CustomerServicePlanCreateDTO, CustomerProducts>();
            CreateMap<CustomerProducts, CustomerProductsClass>()
                .ForMember(dest => dest.ProductsTitle, opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.ProductstContent, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.ProductCreateTime, opt => opt.MapFrom(src => src.CreateDate));
            CreateMap<CustomerProducts, CustomerPlanningServiceForADayDTO>();
            CreateMap<DemandToEmployeeDTO, Demand>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceiverID))
                .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.CreatorID));

        }
    }
}