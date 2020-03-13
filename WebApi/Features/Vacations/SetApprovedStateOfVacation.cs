using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;

namespace WebApi.Features.Vacations
{
    public class SetApprovedStateOfVacation
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string VacationId { get; set; }
            public bool Approved { get; set; }
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
                var vacation = await _context.Vacations.SingleOrDefaultAsync(x => x.ID == request.VacationId, cancellationToken);

                if (vacation is null)
                    return new GenericResponse { Errors = new[] { $"Vacation with id {request.VacationId} does not exist." } };

                vacation.Approved = request.Approved;

                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }
    }
}
