using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Vacations
{
    public class GetAllVacationsOfEmployee
    {
        public class Query : IRequest<IQueryable<VacationDto>>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IQueryable<VacationDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IQueryable<VacationDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vacations = _context.Vacations.Where(x => x.EmployeeID == request.EmployeeId).ProjectTo<VacationDto>(_mapper.ConfigurationProvider);
                return vacations;
            }
        }

        public class VacationDto
        {
            public string ID { get; set; }
            public DateTime DateAndTime { get; set; }
            public string Reason { get; set; }
            public bool Approved { get; set; }
        }
    }
}
