using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Vacations
{
    public class DeleteVacation
    {
        public class Command : IRequest<bool>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
            [JsonIgnore]
            public string DateAndTime { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, bool>
        {
            private Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                Vacation vacation = await _context.Vacations.SingleOrDefaultAsync(x => x.DateAndTime == DateTime.Parse(request.DateAndTime) && x.EmployeeID == request.EmployeeId);

                if (vacation is null) return false;

                _context.Remove(vacation);
                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
