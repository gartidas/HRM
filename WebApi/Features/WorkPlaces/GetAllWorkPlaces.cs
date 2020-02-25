using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Paging;
using static WebApi.Features.WorkPlaces.GetWorkPlace;

namespace WebApi.Features.WorkPlaces
{
    public class GetAllWorkPlaces
    {
        public class Query : IRequest<PagingResponse<WorkPlaceDto>>
        {
            public Filter Filter { get; set; }
            public PagingReferences PagingReferences { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, PagingResponse<WorkPlaceDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagingResponse<WorkPlaceDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var workPlaces = _context.Workplaces.ProjectTo<WorkPlaceDto>(_mapper.ConfigurationProvider);
                workPlaces = ApplyFiltering(request.Filter, workPlaces);

                var pagedContent = await PagingLogic.GetPagedContent(workPlaces, request.PagingReferences, cancellationToken);
                pagedContent.Content = pagedContent.Content.OrderBy(x => x.Label).ThenBy(x => x.Location);
                return pagedContent;
            }

            private IQueryable<WorkPlaceDto> ApplyFiltering(Filter filter, IQueryable<WorkPlaceDto> query)
            {
                if (!string.IsNullOrEmpty(filter.Label))
                    query = query.Where(x => x.Label.Contains(filter.Label));
                if (!string.IsNullOrEmpty(filter.Location))
                    query = query.Where(x => x.Location.Contains(filter.Location));

                return query;
            }
        }

        public class Filter
        {
            public string Label { get; set; }
            public string Location { get; set; }
        }
    }
}
