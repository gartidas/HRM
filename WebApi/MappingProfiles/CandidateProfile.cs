using AutoMapper;
using WebApi.Entities;
using WebApi.Features.Candidates;

namespace WebApi.MappingProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, GetCandidate.CandidateDto>();
        }
    }
}
