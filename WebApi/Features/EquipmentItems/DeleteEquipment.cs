using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.EquipmentItems
{
    public class DeleteEquipment
    {
        public class Command : IRequest<bool>
        {
            public string EquipmentId { get; set; }
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
                var equipment = await _context.Equipment.SingleOrDefaultAsync(x => x.ID == request.EquipmentId);

                if (equipment is null) return false;

                _context.Remove(equipment);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
