using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using WebApi.Data;

namespace WebApi.Features.Documentation
{
    public class GetAllDocumentsOfCandidate
    {
        public class Query : IRequest<IQueryable<GetAllDocumentsOfEmployee.DocumentDto>>
        {
            [JsonIgnore]
            public string CandidateId { get; set; }
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
                var documents = _context.Documents.Where(x => x.CandidateID == request.CandidateId).ProjectTo<GetAllDocumentsOfEmployee.DocumentDto>(_mapper.ConfigurationProvider);
                return documents;
            }
        }
    }
}
