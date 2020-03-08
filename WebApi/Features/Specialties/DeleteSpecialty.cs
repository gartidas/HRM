using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Specialties
{
    public class DeleteSpecialty
    {
        public class Command : IRequest<bool>
        {
            public string SpecialtyId { get; set; }
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
                var specialty = await _context.Specialties.SingleOrDefaultAsync(x => x.ID == request.SpecialtyId);

                if (specialty is null) return false;

                _context.Remove(specialty);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
