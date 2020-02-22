using AutoMapper;
using System.Linq;
using WebApi.Entities;
using WebApi.Features.Candidates;
using WebApi.Features.FormerEmployees;

namespace WebApi.MappingProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, GetCandidate.CandidateDto>()
                .ForMember(dest => dest.Documentation, opt =>
                {
                    opt.MapFrom(x => x.Documentation.Select(d => new GetFormerEmployee.DocumentationDto
                    {
                        ID = d.ID,
                        Name = d.Name,
                        Content = d.Content
                    }));
                });
        }
    }
}
