using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace Project.MapperProfiles
{
    public class OpsPlanProfile: Profile
    {
        public OpsPlanProfile()
        {
            CreateMap<EmployeeCalendarPlanCreateDTO, EmployeeCalendar>();
            CreateMap<CustomerServicePlanCreateDTO, EmployeeCalendar>();
            CreateMap<EmployeeCalendar, EmployeeCalendarPlanCreateDTO>();
        }
    }
}