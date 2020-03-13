using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Evaluations
{
    public class GetAllEvaluationsOfEmployee
    {
        public class Query : IRequest<IQueryable<EvaluationDto>>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IQueryable<EvaluationDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IQueryable<EvaluationDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var evaluations = _context.Evaluations.Where(x => x.EmployeeID == request.EmployeeId).ProjectTo<EvaluationDto>(_mapper.ConfigurationProvider);
                return evaluations;
            }
        }

        public class EvaluationDto
        {
            public string ID { get; set; }
            public string Description { get; set; }
            public EvaluationWeight Weight { get; set; }
            public bool Type { get; set; }
            public HR_WorkerDto HR_Worker { get; set; }
        }

        public class HR_WorkerDto
        {
            public string ID { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }
    }
}
