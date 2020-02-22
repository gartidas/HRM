using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;
using static WebApi.Features.FormerEmployees.GetFormerEmployee;

namespace WebApi.Features.Employees
{
    public class GetEmployee
    {
        public class Query : IRequest<EmployeeDto>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, EmployeeDto>
        {
            private UserManager<ApplicationUser> _userManager;
            private Context _context;
            private IMapper _mapper;

            public QueryHandler(UserManager<ApplicationUser> userManager, Context context, IMapper mapper)
            {
                _userManager = userManager;
                _context = context;
                _mapper = mapper;
            }

            public async Task<EmployeeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.EmployeeId);
                if (employee is null) return null;

                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                employeeDto.Role = (await _userManager.GetRolesAsync(employee)).Single();

                return employeeDto;
            }
        }

        public class EmployeeDto
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string EmailAddress { get; set; }
            public string Password { get; set; }
            public string PhoneNumber { get; set; }
            public string BirthCertificateNumber { get; set; }
            public DateTime BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string Specialty { get; set; }
            public string AddressOfPermanentResidence { get; set; }
            public string Citizenship { get; set; }
            public bool Gender { get; set; }
            public double Salary { get; set; }
            public int NumberOfVacationDays { get; set; }
            public string WorkPlaceID { get; set; }
            public string Role { get; set; }
            public IEnumerable<DocumentationDto> Documentation { get; set; }
            public IEnumerable<EquipmentDto> Equipment { get; set; }
        }
        public class EquipmentDto
        {
            public string ID { get; set; }
            public string Label { get; set; }
        }
    }
}
