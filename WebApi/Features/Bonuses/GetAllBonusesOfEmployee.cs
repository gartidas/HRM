using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Bonuses
{
    public class GetAllBonusesOfEmployee
    {
        public class Query : IRequest<IQueryable<BonusDto>>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IQueryable<BonusDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IQueryable<BonusDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bonuses = _context.Bonuses.Where(x => x.EmployeeID == request.EmployeeId).ProjectTo<BonusDto>(_mapper.ConfigurationProvider);
                return bonuses;
            }
        }

        public class BonusDto
        {
            public string ID { get; set; }
            public string Description { get; set; }
            public int Value { get; set; }
            public DateTime GrantedDate { get; set; }
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
