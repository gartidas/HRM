using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.CorporateEvents
{
    public class GetCorporateEvent
    {
        public class Query : IRequest<CorporateEventDto>
        {
            [JsonIgnore]
            public string CorporateEventId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, CorporateEventDto>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CorporateEventDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var corporateEvent = await _context.CorporateEvents.Include(x => x.EmployeeCorporateEvent).ThenInclude(x => x.Employee).ThenInclude(x => x.IdentityUser).Include(x => x.WorkPlaceLeaderCorporateEvent).ThenInclude(x => x.WorkPlaceLeader).ThenInclude(x => x.IdentityUser).SingleOrDefaultAsync(x => x.ID == request.CorporateEventId);
                if (corporateEvent is null) return null;

                return _mapper.Map<CorporateEventDto>(corporateEvent);
            }
        }

        public class CorporateEventDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string RequestDescription { get; set; }
            public string Location { get; set; }
            public DateTime DateAndTime { get; set; }
            public List<InvitedWorkPlaceLeaderDto> InvitedWorkPlaceLeaders { get; set; }
            public List<InvitedEmployeeDto> InvitedEmployees { get; set; }
        }

        public class InvitedEmployeeDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Specialty { get; set; }
            public WorkPlaceDto WorkPlace { get; set; }
        }

        public class InvitedWorkPlaceLeaderDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Specialty { get; set; }
            public WorkPlaceDto WorkPlace { get; set; }
        }

        public class WorkPlaceDto
        {
            public string ID { get; set; }
            public string Label { get; set; }
            public string Location { get; set; }
        }
    }
}
