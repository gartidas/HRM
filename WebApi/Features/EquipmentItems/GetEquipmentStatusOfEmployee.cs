using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.EquipmentItems
{
    public class GetEquipmentStatusOfEmployee
    {
        public class Query : IRequest<int>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, int>
        {
            private Context _context;

            public QueryHandler(Context context)
            {
                _context = context;
            }

            public async Task<int> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.EmployeeId);
                return (int)employee.EquipmentStatus;
            }
        }
    }
}
