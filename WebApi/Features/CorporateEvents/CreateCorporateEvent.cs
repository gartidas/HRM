using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.CorporateEvents
{
    public class CreateCorporateEvent
    {
        public class Command : IRequest<GenericResponse>
        {
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
                if (await _context.CorporateEvents.AnyAsync(x => x.Name == request.Name && x.Location == request.Location && x.DateAndTime == request.DateAndTime))
                    return new GenericResponse { Errors = new[] { $"Event already exists" } };

                var corporateEvent = new CorporateEvent
                {
                    Name = request.Name,
                    RequestDescription = request.RequestDescription,
                    Location = request.Location,
                    DateAndTime = request.DateAndTime
                };

                await _context.AddAsync(corporateEvent);

                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).Must(x => x.Length > 0).WithMessage("Is Required");
                RuleFor(x => x.Location).Must(x => x.Length > 0).WithMessage("Is Required");
                RuleFor(x => x.DateAndTime).Must(x => x > DateTime.UtcNow).WithMessage("Date must be in the future");
            }
        }
    }
}
