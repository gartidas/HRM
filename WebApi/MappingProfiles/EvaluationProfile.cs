using AutoMapper;
using WebApi.Entities;
using WebApi.Features.Evaluations;

namespace WebApi.MappingProfiles
{
    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<Evaluation, GetAllEvaluationsOfEmployee.EvaluationDto>()
                .ForMember(dest => dest.HR_Worker, cfg => cfg
                   .MapFrom(source => new GetAllEvaluationsOfEmployee.HR_WorkerDto
                   {
                       ID = source.HR_Worker.ID,
                       Name = $"{source.HR_Worker.IdentityUser.Name} {source.HR_Worker.IdentityUser.Surname}",
                       Email = source.HR_Worker.IdentityUser.Email
                   }));
        }

    }
}
