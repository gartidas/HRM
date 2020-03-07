using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Documentation
{
    public class DeleteDocument
    {
        public class Command : IRequest<bool>
        {
            public string DocumentId { get; set; }
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
                var document = await _context.Documents.SingleOrDefaultAsync(x => x.ID == request.DocumentId);

                if (document is null) return false;

                _context.Remove(document);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
