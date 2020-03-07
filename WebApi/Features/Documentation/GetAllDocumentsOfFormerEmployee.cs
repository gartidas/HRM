using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using WebApi.Data;

namespace WebApi.Features.Documentation
{
    public class GetAllDocumentsOfFormerEmployee
    {
        public class Query : IRequest<IQueryable<GetAllDocumentsOfEmployee.DocumentDto>>
        {
            [JsonIgnore]
            public string FormerEmployeeId { get; set; }
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

            public IQueryable<GetAllDocumentsOfEmployee.DocumentDto> Handle(Query request)
            {
                var documents = _context.Documents.Where(x => x.FormerEmployeeID == request.FormerEmployeeId).ProjectTo<GetAllDocumentsOfEmployee.DocumentDto>(_mapper.ConfigurationProvider);
                return documents;
            }
        }
    }
}
