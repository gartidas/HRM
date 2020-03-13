using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Evaluations
{
    public class CreateEvaluation
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeID { get; set; }
            [JsonIgnore]
            public string HR_WorkerID { get; set; }
            public string Description { get; set; }
            public EvaluationWeight Weight { get; set; }
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
                var hr_worker = await _context.HR_Workers.FindAsync(request.HR_WorkerID);
                var employee = await _context.Employees.FindAsync(request.EmployeeID);

                if (employee == null)
                    return new GenericResponse { Errors = new[] { "Employee not found." } };
                if (hr_worker == null)
                    return new GenericResponse { Errors = new[] { "HR worker not found." } };
                if (hr_worker.ID == employee.ID)
                    return new GenericResponse { Errors = new[] { "Cant evaluate yourself." } };

                var evaluation = new Evaluation
                {
                    Description = request.Description,
                    Weight = request.Weight,
                    Type = request.Type,
                    HR_Worker = hr_worker,
                    Employee = employee,
                };

                await _context.Evaluations.AddAsync(evaluation);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Weight).Must(x => (int)x >= 1 && (int)x <= 3).WithMessage("Must be between 1 and 3.");
                RuleFor(x => x.Description).Must(x => x.Length > 0).WithMessage("Is Required.");
            }
        }
    }
}
