using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Bonuses
{
    public class CreateBonus
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeID { get; set; }
            [JsonIgnore]
            public string HR_WorkerID { get; set; }
            public string Description { get; set; }
            public int Value { get; set; }
            public DateTime GrantedDate { get; set; }
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
                    return new GenericResponse { Errors = new[] { "Cant grant bonus to yourself." } };

                var bonus = new Bonus
                {
                    Description = request.Description,
                    Value = request.Value,
                    GrantedDate = request.GrantedDate,
                    HR_Worker = hr_worker,
                    Employee = employee,
                };

                await _context.Bonuses.AddAsync(bonus);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Value).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.Description).Must(x => x.Length > 0).WithMessage("Is Required.");
            }
        }
    }
}
