using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.Specialties
{
    public class GetAllSpecialtesOfWorkPlace
    {
        public class Query : IRequest<IQueryable<SpecialtyDto>>
        {
            [JsonIgnore]
            public string WorkPlaceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, IQueryable<SpecialtyDto>>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IQueryable<SpecialtyDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var specialties = _context.Specialties.Where(x => x.WorkplaceID == request.WorkPlaceId).ProjectTo<SpecialtyDto>(_mapper.ConfigurationProvider);
                return specialties;
            }
        }

        public class SpecialtyDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public int NumberOfEmployees { get; set; }
            public bool Type { get; set; }
        }
    }
}
