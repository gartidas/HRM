using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Paging;
using static WebApi.Features.CorporateEvents.GetCorporateEvent;

namespace WebApi.Features.CorporateEvents
{
    public class GetAllCorporateEvents
    {
        public class Query : IRequest<PagingResponse<CorporateEventDto>>
        {
            public Filter Filter { get; set; }
            public PagingReferences PagingReferences { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, PagingResponse<CorporateEventDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagingResponse<CorporateEventDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var corporateEvents = _context.CorporateEvents.Where(x => x.DateAndTime > DateTime.Now).ProjectTo<CorporateEventDto>(_mapper.ConfigurationProvider);
                corporateEvents = ApplyFiltering(request.Filter, corporateEvents);

                var pagedContent = await PagingLogic.GetPagedContent(corporateEvents, request.PagingReferences, cancellationToken);
                pagedContent.Content = pagedContent.Content.OrderBy(x => x.Name).ThenBy(x => x.Location);
                return pagedContent;
            }

            private IQueryable<CorporateEventDto> ApplyFiltering(Filter filter, IQueryable<CorporateEventDto> query)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(x => x.Name.Contains(filter.Name));
                if (!string.IsNullOrEmpty(filter.Location))
                    query = query.Where(x => x.Location.Contains(filter.Location));

                return query;
            }
        }

        public class Filter
        {
            public string Name { get; set; }
            public string Location { get; set; }
        }
    }
}
