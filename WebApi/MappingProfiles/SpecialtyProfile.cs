using AutoMapper;
using WebApi.Entities;
using static WebApi.Features.Specialties.GetAllSpecialtesOfWorkPlace;

namespace WebApi.MappingProfiles
{
    public class SpecialtyProfile : Profile
    {
        public SpecialtyProfile()
        {
            CreateMap<Specialty, SpecialtyDto>();
        }

    }
}
