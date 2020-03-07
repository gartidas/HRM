using AutoMapper;
using WebApi.Domain.IdentityModels;
using WebApi.Entities;
using WebApi.Features.Employees;

namespace WebApi.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<HireEmployee.Command, RegisterModel>();
            CreateMap<ApplicationUser, GetEmployee.EmployeeData>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.Email));

            CreateMap<Employee, GetEmployee.EmployeeDto>()
                .ForMember(dest => dest.WorkPlace, opt => opt
                   .MapFrom(source => new GetEmployee.EmployeeWorkPlaceDto
                   {
                       ID = source.WorkPlace.ID,
                       Label = source.WorkPlace.Label,
                       Location = source.WorkPlace.Location
                   }));

        }
    }
}
