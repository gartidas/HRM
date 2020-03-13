using AutoMapper;
using WebApi.Entities;
using WebApi.Features.Bonuses;

namespace WebApi.MappingProfiles
{
    public class BonusProfile : Profile
    {
        public BonusProfile()
        {
            CreateMap<Bonus, GetAllBonusesOfEmployee.BonusDto>()
               .ForMember(dest => dest.HR_Worker, cfg => cfg
                  .MapFrom(source => new GetAllBonusesOfEmployee.HR_WorkerDto
                  {
                      ID = source.HR_Worker.ID,
                      Name = $"{source.HR_Worker.IdentityUser.Name} {source.HR_Worker.IdentityUser.Surname}",
                      Email = source.HR_Worker.IdentityUser.Email
                  }));
        }
    }
}
