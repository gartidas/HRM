using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Paging;
using static WebApi.Features.FormerEmployees.GetFormerEmployee;

namespace WebApi.Features.FormerEmployees
{
    public class GetAllFormerEmployees
    {
        public class Query : IRequest<PagingResponse<FormerEmployeeDto>>
        {
            public Filter Filter { get; set; }
            public PagingReferences PagingReferences { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, PagingResponse<FormerEmployeeDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagingResponse<FormerEmployeeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var formerEmployees = _context.FormerEmployees.ProjectTo<FormerEmployeeDto>(_mapper.ConfigurationProvider);
                formerEmployees = ApplyFiltering(request.Filter, formerEmployees);

                var pagedContent = await PagingLogic.GetPagedContent(formerEmployees, request.PagingReferences, cancellationToken);
                pagedContent.Content = pagedContent.Content.OrderBy(x => x.Surname).ThenBy(x => x.Name).ThenBy(x => x.Specialty);
                return pagedContent;
            }

            private IQueryable<FormerEmployeeDto> ApplyFiltering(Filter filter, IQueryable<FormerEmployeeDto> query)
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
