using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace Project.MapperProfiles
{
    public class ServicesProfile:Profile
    {
        public ServicesProfile()
        {
            CreateMap<ServicePackageandServiceListDTO, Services>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ServiceDescription));
            CreateMap<ServicePackageandServiceListDTO, Package>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PackageName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.PackageDescription));
            CreateMap<EditServiceDTO, Services>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ServiceName))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ServiceID))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ServiceDescription));
        }
    }
}