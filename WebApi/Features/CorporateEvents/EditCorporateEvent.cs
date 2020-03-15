using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;

namespace WebApi.Features.CorporateEvents
{
    public class EditCorporateEvent
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string CorporateEventId { get; set; }
            public string Name { get; set; }
            public string RequestDescription { get; set; }
            public string Location { get; set; }
            public DateTime DateAndTime { get; set; }
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
                var corporateEvent = await _context.CorporateEvents.SingleOrDefaultAsync(x => x.ID == request.CorporateEventId, cancellationToken);

                if (corporateEvent is null)
                    return new GenericResponse { Errors = new[] { $"Event with id {request.CorporateEventId} does not exist." } };

                if (await _context.CorporateEvents.AnyAsync(x => x.Name == request.Name && x.Location == request.Location && x.DateAndTime == request.DateAndTime))
                    return new GenericResponse { Errors = new[] { $"Event already exists." } };


                corporateEvent.Name = request.Name;
                corporateEvent.RequestDescription = request.RequestDescription;
                corporateEvent.Location = request.Location;
                corporateEvent.DateAndTime = request.DateAndTime;

                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Location).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.DateAndTime).Must(x => x > DateTime.UtcNow).WithMessage("Date must be in the future");
            }
        }
    }
}
