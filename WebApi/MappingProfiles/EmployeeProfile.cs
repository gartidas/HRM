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
            CreateMap<Hire.Command, RegisterModel>();

            CreateMap<ApplicationUser, GetEmployee.EmployeeDto>()
                .ForMember(to => to.EmailAddress, from => from.MapFrom(x => x.Email))
                .ForMember(to => to.Id, from => from.MapFrom(x => x.Id));

            CreateMap<ApplicationUser, GetEmployee.EmployeeDto>()
                .ForMember(to => to.EmailAddress, from => from.MapFrom(x => x.Email))
                .ForMember(to => to.Id, from => from.MapFrom(x => x.Id));
        }
    }
}
