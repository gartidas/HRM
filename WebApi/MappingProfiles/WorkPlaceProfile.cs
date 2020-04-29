using AutoMapper;
using WebApi.Entities;
using WebApi.Features.WorkPlaces;

namespace WebApi.MappingProfiles
{
    public class WorkPlaceProfile : Profile
    {
        public WorkPlaceProfile()
        {
            CreateMap<WorkPlace, GetWorkPlace.WorkPlaceDto>();
            CreateMap<WorkPlace, GetAllWorkPlaces.WorkPlaceDto>();
        }
    }
}
