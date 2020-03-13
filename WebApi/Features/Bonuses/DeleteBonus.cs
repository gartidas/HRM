using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Bonuses
{
    public class DeleteBonus
    {
        public class Command : IRequest<bool>
        {
            public string BonusId { get; set; }
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
                var bonus = await _context.Bonuses.SingleOrDefaultAsync(x => x.ID == request.BonusId);

                if (bonus is null) return false;

                _context.Remove(bonus);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
