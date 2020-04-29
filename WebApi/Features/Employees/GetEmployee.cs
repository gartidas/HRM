using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entities;

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
                var employee = await _context.Employees.Include(x => x.IdentityUser).Include(x => x.WorkPlace).SingleOrDefaultAsync(x => x.ID == request.EmployeeId);
                if (employee is null) return null;

                var employeeDto = _mapper.Map<EmployeeDto>(employee);
                employeeDto.Data = _mapper.Map<EmployeeData>(employee.IdentityUser);
                employeeDto.Data.Role = (await _userManager.GetRolesAsync(employee.IdentityUser)).Single();
                employeeDto.Data.IsAssignedWorkplaceLeader = await _context.Workplaces.AnyAsync(x => x.WorkPlaceLeaderID == request.EmployeeId);

                return employeeDto;
            }
        }

        public class EmployeeData
        {
            public string Title { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string EmailAddress { get; set; }
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
            public string IdCardNumber { get; set; }
            public string DrivingLicenceNumber { get; set; }
            public string HealthInsuranceCompany { get; set; }
            public int NumberOfChildren { get; set; }
            public int FamilyStatus { get; set; }
            public string NameOfTheBank { get; set; }
            public string AccountNumber { get; set; }
            public string Role { get; set; }
            public bool IsAssignedWorkplaceLeader { get; set; }
        }
        public class EmployeeDto
        {
            public string ID { get; set; }
            public EmployeeData Data { get; set; }
            public EmployeeWorkPlaceDto WorkPlace { get; set; }
        }
        public class EmployeeWorkPlaceDto
        {
            public string ID { get; set; }
            public string Label { get; set; }
            public string Location { get; set; }
        }
    }
}
