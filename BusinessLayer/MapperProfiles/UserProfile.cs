using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace Project.MapperProfiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<EmployeeDefineAndListDTO, ApplicationUser>().ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<CustomerCreateAndListDTO, ApplicationUser>().ForMember(dest => dest.NameSurname, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<ApplicationUser, CustomerCardDTO>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.NameSurname))
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerMail, opt => opt.MapFrom(src => src.Email));



        }
    }
}