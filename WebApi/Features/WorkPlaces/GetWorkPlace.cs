using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.WorkPlaces
{
    public class GetWorkPlace
    {
        public class Query : IRequest<WorkPlaceDto>
        {
            [JsonIgnore]
            public string WorkPlaceId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, WorkPlaceDto>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<WorkPlaceDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var workPlace = await _context.Workplaces.Include(x => x.Employees).ThenInclude(x => x.IdentityUser).Include(x => x.Specialties).Include(x => x.WorkPlaceLeader).ThenInclude(x => x.IdentityUser).SingleOrDefaultAsync(x => x.ID == request.WorkPlaceId);
                if (workPlace is null) return null;
                return _mapper.Map<WorkPlaceDto>(workPlace);
            }
        }

        public class WorkPlaceDto
        {
            public string ID { get; set; }
            public string Label { get; set; }
            public string Location { get; set; }
            public IEnumerable<EmployeeDto> Employees { get; set; }
            public IEnumerable<SpecialtyDto> Specialties { get; set; }
            public EmployeeDto WorkPlaceLeader { get; set; }
        }

        public class EmployeeDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Specialty { get; set; }
            public int NumberOfWorkedOffDays { get; set; }
        }

        public class SpecialtyDto
        {
            public string Name { get; set; }
            public int NumberOfEmployees { get; set; }
            public bool Type { get; set; }
        }
    }
}
