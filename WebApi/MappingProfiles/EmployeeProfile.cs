using AutoMapper;
using System.Linq;
using WebApi.Domain.IdentityModels;
using WebApi.Entities;
using WebApi.Features.Employees;
using WebApi.Features.FormerEmployees;

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
                .ForMember(dest => dest.Documentation, opt =>
                {
                    opt.MapFrom(x => x.Documentation.Select(d => new GetFormerEmployee.DocumentationDto
                    {
                        ID = d.ID,
                        Name = d.Name,
                        Content = d.Content
                    }));
                })
                .ForMember(dest => dest.Equipment, opt =>
                {
                    opt.MapFrom(x => x.Equipment.Select(d => new GetEmployee.EquipmentDto
                    {
                        ID = d.ID,
                        Label = d.Label
                    }));
                })
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
