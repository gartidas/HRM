using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.CorporateEvents
{
    public class DeleteCorporateEvent
    {
        public class Command : IRequest<bool>
        {
            public string CorporateEventId { get; set; }
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
                var corporateEvent = await _context.CorporateEvents.SingleOrDefaultAsync(x => x.ID == request.CorporateEventId);

                if (corporateEvent is null) return false;

                _context.Remove(corporateEvent);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
