using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.EquipmentItems
{
    public class SetEquipmentStatusOfEmployee
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
            public EquipmentStatus EquipmentStatus { get; set; }
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
                var employee = _context.Users.Single(x => x.Id == request.EmployeeId);

                if (employee is null) return new GenericResponse { Errors = new[] { "User doesn't exist" } };

                employee.EquipmentStatus = request.EquipmentStatus;

                await _context.SaveChangesAsync(cancellationToken);

                return new GenericResponse { Success = true };
            }
        }
    }
}
