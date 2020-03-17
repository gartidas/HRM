using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities.Joins;

namespace WebApi.Features.CorporateEvents
{
    public class AssignWorkPlaceLeadersToCorporateEvent
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
                var corporateEvent = await _context.CorporateEvents.Include(x => x.WorkPlaceLeaderCorporateEvent).ThenInclude(x => x.WorkPlaceLeader).SingleOrDefaultAsync(x => x.ID == request.CorporateEventId);

                if (corporateEvent is null) return new GenericResponse { Errors = new[] { $"Event with id {request.CorporateEventId} does not exist." } };


                var workPlaceLeaders = _context.WorkPlaceLeaders.Where(x => request.WorkPlaceLeaderIds.Contains(x.ID));

                foreach (var join in corporateEvent.WorkPlaceLeaderCorporateEvent)
                {
                    _context.Remove(join);
                }

                await _context.SaveChangesAsync();

                foreach (var workPlaceLeader in workPlaceLeaders)
                {
                    var join = new WorkPlaceLeaderCorporateEvent
                    {
                        CorporateEvent = corporateEvent,
                        WorkPlaceLeader = workPlaceLeader
                    };

                    await _context.AddAsync(join);
                }

                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.WorkPlaceLeaderIds).Must(x => x.Any()).WithMessage("Must contain at least one workplace leader");
            }
        }
    }
}
