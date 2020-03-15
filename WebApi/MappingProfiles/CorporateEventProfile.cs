using AutoMapper;
using WebApi.Entities;
using WebApi.Features.CorporateEvents;

namespace WebApi.MappingProfiles
{
    public class CorporateEventProfile : Profile
    {
        public CorporateEventProfile()
        {
            CreateMap<CorporateEvent, GetCorporateEvent.CorporateEventDto>();
        }
    }
}
