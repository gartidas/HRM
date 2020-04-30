using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.WorkPlaces
{
    public class CreateWorkPlace
    {
        public class Command : IRequest<GenericResponse>
        {
            public string Label { get; set; }
            public string Location { get; set; }
            public string WorkPlaceLeaderID { get; set; }
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
                if (await _context.Workplaces.AnyAsync(x => x.Label == request.Label && x.Location == request.Location))
                    return new GenericResponse { Errors = new[] { $"Work place labeled {request.Label} already exists at {request.Location}." } };

                var workPlace = new WorkPlace
                {
                    Label = request.Label,
                    Location = request.Location
                };

                if (request.WorkPlaceLeaderID != default)
                {
                    var workPlaceLeader = await _context.WorkPlaceLeaders.Include(x => x.WorkPlace).ThenInclude(x => x.WorkPlaceLeader).SingleOrDefaultAsync(x => x.ID == request.WorkPlaceLeaderID);

                    if (workPlaceLeader == null)
                        return new GenericResponse
                        {
                            Errors = new[] { "Work place leader not found." }
                        };

                    var leaderEmployee = await _context.Employees.Include(x => x.WorkPlace).ThenInclude(x => x.Employees).SingleOrDefaultAsync(x => x.ID == workPlaceLeader.ID);

                    if (leaderEmployee.WorkPlace != null)
                        leaderEmployee.WorkPlace.Employees.Remove(leaderEmployee);


                    if (workPlaceLeader.WorkPlace != null)
                    {
                        workPlaceLeader.WorkPlace.WorkPlaceLeader = null;
                    }

                    workPlace.WorkPlaceLeader = workPlaceLeader;
                    workPlace.WorkPlaceLeaderID = request.WorkPlaceLeaderID;
                    workPlace.Employees = new System.Collections.Generic.List<Employee>() { leaderEmployee };
                }

                await _context.Workplaces.AddAsync(workPlace);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Label).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Location).Must(x => x.Length > 0).WithMessage("Is Required.");
            }
        }
    }
}
