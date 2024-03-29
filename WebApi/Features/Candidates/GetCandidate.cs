﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Candidates
{
    public class GetCandidate
    {
        public class Query : IRequest<CandidateDto>
        {
            [JsonIgnore]
            public string CandidateId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, CandidateDto>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CandidateDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var candidate = await _context.Candidates.ProjectTo<CandidateDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(x => x.Id == request.CandidateId);
                if (candidate is null) return null;
                return candidate;
            }
        }

        public class CandidateDto
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Education { get; set; }
            public string Specialty { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public double RequestedSalary { get; set; }
            public int Evaluation { get; set; }
            public Status Status { get; set; }
            public string AdditionalInfo { get; set; }
        }
    }
}
