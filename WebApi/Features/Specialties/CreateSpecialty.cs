using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Specialties
{
    public class CreateSpecialty
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string WorkplaceID { get; set; }
            public string Name { get; set; }
            public int NumberOfEmployees { get; set; }
            public bool Type { get; set; }
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
                if (await _context.Specialties.AnyAsync(x => x.Name == request.Name && x.Type == request.Type && x.WorkplaceID == request.WorkplaceID))
                    return new GenericResponse { Errors = new[] { "This set of specialtes already exists in this workplace." } };

                var specialty = new Specialty
                {
                    Name = request.Name,
                    NumberOfEmployees = request.NumberOfEmployees,
                    Type = request.Type,
                    Workplace = await _context.Workplaces.FindAsync(request.WorkplaceID)
                };

                await _context.Specialties.AddAsync(specialty);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.NumberOfEmployees).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.Name).Must(x => x.Length > 0).WithMessage("Is Required.");
            }
        }
    }
}
