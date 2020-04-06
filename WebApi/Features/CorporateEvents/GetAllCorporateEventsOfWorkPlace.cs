using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.CorporateEvents
{
    public class GetAllCorporateEventsOfWorkPlace
    {
        public class Query : IRequest<List<CorporateEventDto>>
        {
            [JsonIgnore]
            public string WorkPlaceLeaderId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, List<CorporateEventDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CorporateEventDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var empcorpev = _context.WorkPlaceLeaderCorporateEvents.Where(x => x.WorkPlaceLeaderID == request.WorkPlaceLeaderId && x.CorporateEvent.DateAndTime > DateTime.Now).Include(x => x.CorporateEvent).Include(x => x.WorkPlaceLeader);

                if (empcorpev.Count() == 0)
                    return null;

                List<CorporateEvent> events = new List<CorporateEvent>();

                foreach (var corpevent in empcorpev)
                {
                    events.Add(corpevent.CorporateEvent);
                }

                if (events.Count() == 0)
                    return null;

                List<CorporateEventDto> result = new List<CorporateEventDto>();

                foreach (var corpevent in events)
                {
                    result.Add(_mapper.Map<CorporateEventDto>(corpevent));
                }

                return await Task.FromResult(result);
            }
        }

        public class CorporateEventDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public DateTime DateAndTime { get; set; }
            public string RequestDescription { get; set; }
        }
    }
}
