using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Documentation
{
    public class CreateDocumentForCandidate
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string CandidateId { get; set; }
            public string Name { get; set; }
            public byte[] Content { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Documents.AnyAsync(x => x.Name == request.Name))
                    return new GenericResponse { Errors = new[] { $"File with name {request.Name} is already assigned to this subject." } };

                var document = new Document
                {
                    Name = request.Name,
                    Content = request.Content,
                    CandidateID = request.CandidateId,
                    Candidate = await _context.Candidates.FindAsync(request.CandidateId)
                };

                await _context.Documents.AddAsync(document);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }
    }
}
