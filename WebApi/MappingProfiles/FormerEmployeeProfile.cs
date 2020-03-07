using AutoMapper;
using WebApi.Entities;
using WebApi.Features.FormerEmployees;

namespace WebApi.MappingProfiles
{
    public class FormerEmployeeProfile : Profile
    {
        public FormerEmployeeProfile()
        {
            CreateMap<FormerEmployee, GetFormerEmployee.FormerEmployeeDto>()
                .ForMember(dest => dest.HR_Worker, cfg => cfg
                   .MapFrom(source => new GetFormerEmployee.HR_WorkerDto
                   {
                       ID = source.HR_Worker.ID,
                       Name = $"{source.HR_Worker.IdentityUser.Name} {source.HR_Worker.IdentityUser.Surname}",
                       Email = source.HR_Worker.IdentityUser.Email
                   }));

        }
    }
}
