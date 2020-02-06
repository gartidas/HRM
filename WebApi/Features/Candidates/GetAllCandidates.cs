﻿using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;
using WebApi.Paging;
using static WebApi.Features.Candidates.GetCandidate;

namespace WebApi.Features.Candidates
{
    public class GetAllCandidates
    {
        public class Query : IRequest<PagingResponse<CandidateDto>>
        {
            public Filter Filter { get; set; }
            public PagingReferences PagingReferences { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, PagingResponse<CandidateDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagingResponse<CandidateDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var candidates = _context.Candidates.AsQueryable();
                candidates = ApplyFiltering(request.Filter, candidates);

                var pagedContent = await PagingLogic.GetPagedContent(candidates, request.PagingReferences, _mapper.Map<CandidateDto>, cancellationToken);
                pagedContent.Content = pagedContent.Content.OrderByDescending(x => x.Evaluation).ThenBy(x => x.RequestedSalary).ThenBy(x => x.Name);
                return pagedContent;
            }

            private IQueryable<Candidate> ApplyFiltering(Filter filter, IQueryable<Candidate> query)
            {
                if (!string.IsNullOrEmpty(filter.Email))
                    query = query.Where(x => x.Email.Contains(filter.Email));
                if (!string.IsNullOrEmpty(filter.Specialty))
                    query = query.Where(x => x.Specialty.Contains(filter.Specialty));
                if (!string.IsNullOrEmpty(filter.Surname))
                    query = query.Where(x => x.Surname.Contains(filter.Surname));

                return query;
            }
        }



        public class Filter
        {
            public string Email { get; set; }
            public string Specialty { get; set; }
            public string Surname { get; set; }
        }
    }
}
