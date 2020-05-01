using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
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
            [JsonIgnore]
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
                var employee = await _context.Users.FindAsync(request.EmployeeId);
                var hr_worker = await _context.HR_Workers.FindAsync(request.HR_WorkerID);
                var emp = await _context.Employees.SingleOrDefaultAsync(x => x.ID == request.EmployeeId);

                if (employee == null)
                    return new GenericResponse { Success = false, Errors = new[] { "Employee not found" } };
                if (hr_worker == null)
                    return new GenericResponse { Success = false, Errors = new[] { "HR worker not found" } };

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
                    HR_Worker = hr_worker,
                    TerminationReason = request.TerminationReason,
                    TerminationDate = request.TerminationDate
                };

                _context.FormerEmployees.Add(formerEmployee);
                _context.SaveChanges();

                _context.Employees.Remove(emp);
                _context.Users.Remove(employee);
                _context.SaveChanges();

                return new GenericResponse
                {
                    Success = true
                };

            }
        }
    }
}
