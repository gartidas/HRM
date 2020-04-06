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
    public class RemoveEmployeesFromCorporateEvent
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string CorporateEventId { get; set; }
            public IEnumerable<string> EmployeeIds { get; set; }
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
                List<EmployeeCorporateEvent> events = new List<EmployeeCorporateEvent>();

                foreach (var employee in request.EmployeeIds)
                {
                    events.Add(_context.EmployeeCorporateEvents.Include(x => x.Employee).Include(x => x.CorporateEvent).SingleOrDefault(x => x.EmployeeID == employee && x.CorporateEventID == request.CorporateEventId));
                }

                if (events != null)
                {
                    foreach (var corpEv in events)
                    {
                        _context.EmployeeCorporateEvents.Remove(corpEv);
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
                RuleFor(x => x.EmployeeIds).Must(x => x.Any()).WithMessage("Must contain at least one employee");
            }
        }
    }
}
