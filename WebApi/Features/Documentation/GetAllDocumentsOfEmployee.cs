using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using WebApi.Data;

namespace WebApi.Features.Documentation
{
    public class GetAllDocumentsOfEmployee
    {
        public class Query : IRequest<IQueryable<DocumentDto>>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public IQueryable<DocumentDto> Handle(Query request)
            {
                var documents = _context.Documents.Where(x => x.EmployeeID == request.EmployeeId).ProjectTo<DocumentDto>(_mapper.ConfigurationProvider);
                return documents;
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
