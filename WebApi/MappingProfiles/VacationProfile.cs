using AutoMapper;
using WebApi.Entities;
using WebApi.Features.Vacations;

namespace WebApi.MappingProfiles
{
    public class VacationProfile : Profile
    {
        public VacationProfile()
        {
            CreateMap<Vacation, GetAllVacationsOfEmployee.VacationDto>();
        }
    }
}
