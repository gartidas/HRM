using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.EquipmentItems
{
    public class GetAllEquipmentOfEmployee
    {
        public class Query : IRequest<IQueryable<EquipmentDto>>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IQueryable<EquipmentDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IQueryable<EquipmentDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var equipment = _context.Equipment.Where(x => x.EmployeeID == request.EmployeeId).ProjectTo<EquipmentDto>(_mapper.ConfigurationProvider);
                return await Task.FromResult(equipment); ;
            }
        }

        public class EquipmentDto
        {
            public string ID { get; set; }
            public string Label { get; set; }
        }
    }
}
