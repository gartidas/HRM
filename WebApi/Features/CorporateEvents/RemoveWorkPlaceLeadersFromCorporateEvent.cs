using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities.Joins;

namespace WebApi.Features.CorporateEvents
{
    public class RemoveWorkPlaceLeadersFromCorporateEvent
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string CorporateEventId { get; set; }
            public IEnumerable<string> WorkPlaceLeaderIds { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                List<WorkPlaceLeaderCorporateEvent> events = new List<WorkPlaceLeaderCorporateEvent>();

                foreach (var employee in request.WorkPlaceLeaderIds)
                {
                    events.Add(_context.WorkPlaceLeaderCorporateEvents.Include(x => x.WorkPlaceLeader).Include(x => x.CorporateEvent).SingleOrDefault(x => x.WorkPlaceLeaderID == employee && x.CorporateEventID == request.CorporateEventId));
                }

                if (events != null)
                {
                    foreach (var corpEv in events)
                    {
                        _context.WorkPlaceLeaderCorporateEvents.Remove(corpEv);
                    }
                }

                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.WorkPlaceLeaderIds).Must(x => x.Any()).WithMessage("Must contain at least one workplace leader.");
            }
        }
    }
}
