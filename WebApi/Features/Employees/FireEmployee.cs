using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Employees
{
    public class FireEmployee
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
            public string HR_WorkerID { get; set; }
            public string TerminationReason { get; set; }
            public DateTime TerminationDate { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private UserManager<ApplicationUser> _userManager;
            private readonly Context _context;

            public CommandHandler(UserManager<ApplicationUser> userManager, Context context)
            {
                _userManager = userManager;
                _context = context;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _userManager.FindByIdAsync(request.EmployeeId);
                var hr_worker = await _context.HR_Workers.FindAsync(request.HR_WorkerID);
                var roleString = (await _userManager.GetRolesAsync(employee)).Single();
                var documentation = (await _context.Employees.FindAsync(request.EmployeeId)).Documentation;


                var formerEmployee = new FormerEmployee
                {
                    Title = employee.Title,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    BirthCertificateNumber = employee.BirthCertificateNumber,
                    BirthDate = employee.BirthDate,
                    BirthPlace = employee.BirthPlace,
                    Specialty = employee.Specialty,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    AddressOfPermanentResidence = employee.AddressOfPermanentResidence,
                    Citizenship = employee.Citizenship,
                    Gender = employee.Gender,
                    Salary = employee.Salary,
                    NumberOfVacationDays = employee.NumberOfVacationDays,
                    NumberOfWorkedOffDays = employee.NumberOfWorkedOffDays,
                    Documentation = documentation,
                    HR_Worker = hr_worker,
                    TerminationReason = request.TerminationReason,
                    TerminationDate = request.TerminationDate
                };
                await _context.AddAsync(formerEmployee, cancellationToken);
                var result = await _userManager.DeleteAsync(employee);

                return new GenericResponse
                {
                    Success = result.Succeeded,
                    Errors = result.Errors?.Select(x => x.Description)
                };
            }
        }
    }
}
