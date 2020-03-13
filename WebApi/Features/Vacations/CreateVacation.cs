using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Vacations
{
    public class CreateVacation
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
            public DateTime DateAndTime { get; set; }
            public string Reason { get; set; }
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
                if (await _context.Vacations.AnyAsync(x => x.DateAndTime == request.DateAndTime && x.EmployeeID == request.EmployeeId))
                    return new GenericResponse { Errors = new[] { "Vacation already planned for this date." } };

                var vacation = new Vacation
                {
                    DateAndTime = request.DateAndTime,
                    Reason = request.Reason,
                    Employee = await _context.Employees.FindAsync(request.EmployeeId),
                    EmployeeID = request.EmployeeId
                };

                await _context.Vacations.AddAsync(vacation);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }
    }
}
