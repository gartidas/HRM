using AutoMapper;
using WebApi.Controllers.Responses;
using WebApi.Domain;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Employees;
using WebApi.Features.Users;

namespace WebApi.MappingProfiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<AuthenticationResult, Login.CommandResponse>();
            CreateMap<OperationResult, GenericResponse>();
            CreateMap<Hire.Command, RegisterModel>();
        }
    }
}
