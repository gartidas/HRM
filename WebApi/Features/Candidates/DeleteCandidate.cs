using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Candidates
{
    public class DeleteCandidate
    {
        public class Command : IRequest<bool>
        {
            public string CandidateId { get; set; }
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
                var candidate = await _context.Candidates.SingleOrDefaultAsync(x => x.ID == request.CandidateId);
                var documentation = candidate.Documentation;
                if (candidate is null) return false;
                if (documentation != null)
                {
                    foreach (var item in documentation)
                    {
                        _context.Remove(item);
                    }
                }
                _context.Remove(candidate);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
