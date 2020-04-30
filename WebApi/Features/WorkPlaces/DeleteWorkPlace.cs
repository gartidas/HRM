using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.WorkPlaces
{
    public class DeleteWorkPlace
    {
        public class Command : IRequest<bool>
        {
            public string WorkPlaceId { get; set; }
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
                var workPlace = await _context.Workplaces.Include(x => x.Employees).SingleOrDefaultAsync(x => x.ID == request.WorkPlaceId);

                if (workPlace is null) return false;

                if (workPlace.Employees != null) return false;

                _context.Remove(workPlace);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
