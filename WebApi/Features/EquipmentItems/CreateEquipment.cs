using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.EquipmentItems
{
    public class CreateEquipment
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
            public string Label { get; set; }
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
                if (await _context.Equipment.AnyAsync(x => x.Label == request.Label && x.EmployeeID == request.EmployeeId))
                    return new GenericResponse { Errors = new[] { $"Item with label {request.Label} already listed" } };

                var equipment = new Equipment
                {
                    EmployeeID = request.EmployeeId,
                    Employee = await _context.Employees.FindAsync(request.EmployeeId),
                    Label = request.Label
                };

                await _context.Equipment.AddAsync(equipment);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }
    }
}
