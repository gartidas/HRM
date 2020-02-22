using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Features.FormerEmployees
{
    public class GetFormerEmployee
    {
        public class Query : IRequest<FormerEmployeeDto>
        {
            [JsonIgnore]
            public string FormerEmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, FormerEmployeeDto>
        {
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(Context context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FormerEmployeeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var formerEmployee = await _context.FormerEmployees.Include(x => x.HR_Worker).ThenInclude(x => x.IdentityUser).Include(x => x.Documentation).SingleOrDefaultAsync(x => x.ID == request.FormerEmployeeId);
                if (formerEmployee is null) return null;
                return _mapper.Map<FormerEmployeeDto>(formerEmployee);
            }
        }

        public class FormerEmployeeDto
        {
            public string ID { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string BirthCertificateNumber { get; set; }
            public DateTime BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string Specialty { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string AddressOfPermanentResidence { get; set; }
            public string Citizenship { get; set; }
            public bool Gender { get; set; }
            public double Salary { get; set; }
            public int NumberOfVacationDays { get; set; }
            public int NumberOfWorkedOffDays { get; set; }
            public HR_WorkerDto HR_Worker { get; set; }
            public string TerminationReason { get; set; }
            public DateTime TerminationDate { get; set; }
            public IEnumerable<DocumentationDto> Documentation { get; set; }
        }

        public class HR_WorkerDto
        {
            public string ID { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
        }

        public class DocumentationDto
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public byte[] Content { get; set; }
        }
    }
}
