using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Vacations
{
    public class DeleteVacation
    {
        public class Command : IRequest<bool>
        {
            public string VacationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, bool>
        {
            private Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var vacation = await _context.Vacations.SingleOrDefaultAsync(x => x.ID == request.VacationId);

                if (vacation is null) return false;

                _context.Remove(vacation);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
