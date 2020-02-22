using AutoMapper;
using System.Linq;
using WebApi.Entities;
using WebApi.Features.WorkPlaces;

namespace WebApi.MappingProfiles
{
    public class WorkPlaceProfile : Profile
    {
        public WorkPlaceProfile()
        {
            CreateMap<WorkPlace, GetWorkPlace.WorkPlaceDto>()
                .ForMember(dest => dest.WorkPlaceLeader, cfg => cfg
                   .MapFrom(source => new GetWorkPlace.EmployeeDto
                   {
                       ID = source.WorkPlaceLeader.ID,
                       Name = $"{source.WorkPlaceLeader.IdentityUser.Name} {source.WorkPlaceLeader.IdentityUser.Surname}",
                       Email = source.WorkPlaceLeader.IdentityUser.Email,
                       Specialty = source.WorkPlaceLeader.IdentityUser.Specialty,
                       NumberOfWorkedOffDays = source.WorkPlaceLeader.IdentityUser.NumberOfWorkedOffDays
                   }))
                .ForMember(dest => dest.Employees, opt =>
                {
                    opt.MapFrom(x => x.Employees.Select(source => new GetWorkPlace.EmployeeDto
                    {
                        ID = source.ID,
                        Name = $"{source.IdentityUser.Name} {source.IdentityUser.Surname}",
                        Email = source.IdentityUser.Email,
                        Specialty = source.IdentityUser.Specialty,
                        NumberOfWorkedOffDays = source.IdentityUser.NumberOfWorkedOffDays
                    }));
                })
                .ForMember(dest => dest.Specialties, opt =>
                {
                    opt.MapFrom(x => x.Specialties.Select(source => new GetWorkPlace.SpecialtyDto
                    {
                        Name = source.Name,
                        NumberOfEmployees = source.NumberOfEmployees,
                        Type = source.Type
                    }));
                });
        }
    }
}
