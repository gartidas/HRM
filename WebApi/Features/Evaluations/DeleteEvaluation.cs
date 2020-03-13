using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Evaluations
{
    public class DeleteEvaluation
    {
        public class Command : IRequest<bool>
        {
            public string EvaluationId { get; set; }
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
                var evaluation = await _context.Evaluations.SingleOrDefaultAsync(x => x.ID == request.EvaluationId);

                if (evaluation is null) return false;

                _context.Remove(evaluation);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
