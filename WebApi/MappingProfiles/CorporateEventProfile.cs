using AutoMapper;
using WebApi.Entities;
using WebApi.Entities.Joins;
using WebApi.Features.CorporateEvents;

namespace WebApi.MappingProfiles
{
    public class CorporateEventProfile : Profile
    {
        public CorporateEventProfile()
        {
            CreateMap<CorporateEvent, GetCorporateEvent.CorporateEventDto>()
                 .ForMember(dest => dest.InvitedWorkPlaceLeaders, cfg => cfg.MapFrom(src => src.WorkPlaceLeaderCorporateEvent))
                 .ForMember(dest => dest.InvitedEmployees, cfg => cfg.MapFrom(src => src.EmployeeCorporateEvent));

            CreateMap<WorkPlaceLeaderCorporateEvent, GetCorporateEvent.InvitedWorkPlaceLeaderDto>()
                .ForMember(dest => dest.ID, cfg => cfg.MapFrom(src => src.WorkPlaceLeader.ID))
                .ForMember(dest => dest.Email, cfg => cfg.MapFrom(src => src.WorkPlaceLeader.IdentityUser.Email))
                .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => (src.WorkPlaceLeader.IdentityUser.Name) + (src.WorkPlaceLeader.IdentityUser.Surname)))
                .ForMember(dest => dest.Specialty, cfg => cfg.MapFrom(src => src.WorkPlaceLeader.IdentityUser.Specialty))
                .ForMember(dest => dest.WorkPlace, cfg => cfg.MapFrom(src => src.WorkPlaceLeader.WorkPlace));

            CreateMap<EmployeeCorporateEvent, GetCorporateEvent.InvitedEmployeeDto>()
               .ForMember(dest => dest.ID, cfg => cfg.MapFrom(src => src.Employee.ID))
               .ForMember(dest => dest.Email, cfg => cfg.MapFrom(src => src.Employee.IdentityUser.Email))
               .ForMember(dest => dest.Name, cfg => cfg.MapFrom(src => (src.Employee.IdentityUser.Name) + (src.Employee.IdentityUser.Surname)))
               .ForMember(dest => dest.Specialty, cfg => cfg.MapFrom(src => src.Employee.IdentityUser.Specialty))
               .ForMember(dest => dest.WorkPlace, cfg => cfg.MapFrom(src => src.Employee.WorkPlace));

            CreateMap<WorkPlace, GetCorporateEvent.WorkPlaceDto>()
                .ForMember(dest => dest.ID, cfg => cfg.MapFrom(src => src.ID))
                .ForMember(dest => dest.Label, cfg => cfg.MapFrom(src => src.Label))
                .ForMember(dest => dest.Location, cfg => cfg.MapFrom(src => src.Location));

            CreateMap<CorporateEvent, GetAllCorporateEventsOfWorkPlace.CorporateEventDto>();

            CreateMap<CorporateEvent, GetAllCorporateEventsOfEmployee.CorporateEventDto>();
        }
    }
}
