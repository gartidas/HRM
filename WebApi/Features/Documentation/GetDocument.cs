using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Documentation
{
    public class GetDocument
    {
        public class Query : IRequest<DocumentDto>
        {
            [JsonIgnore]
            public string DocumentId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, DocumentDto>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DocumentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var document = await _context.Documents.SingleOrDefaultAsync(x => x.ID == request.DocumentId);
                if (document is null) return null;
                return _mapper.Map<DocumentDto>(document);
            }
        }

        public class DocumentDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public byte[] Content { get; set; }
        }
    }
}
