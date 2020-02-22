using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.FormerEmployees
{
    public class DeleteFormerEmployee
    {
        public class Command : IRequest<bool>
        {
            public string FormerEmployeeId { get; set; }
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
                var formerEmployee = await _context.FormerEmployees.SingleOrDefaultAsync(x => x.ID == request.FormerEmployeeId);

                if (formerEmployee is null) return false;

                _context.Remove(formerEmployee);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
