using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Domain.IdentityModels;
using WebApi.Entities;

namespace WebApi.Features.Employees
{
    public class EditEmployee
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string EmployeeId { get; set; }
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
            public Role Role { get; set; }
            public string IdCardNumber { get; set; }
            public string DrivingLicenceNumber { get; set; }
            public string HealthInsuranceCompany { get; set; }
            public int NumberOfChildren { get; set; }
            public FamilyStatus FamilyStatus { get; set; }
            public string NameOfTheBank { get; set; }
            public string AccountNumber { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private Context _context;
            private readonly UserManager<ApplicationUser> _userManager;

            public CommandHandler(Context context, UserManager<ApplicationUser> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _userManager.FindByIdAsync(request.EmployeeId);

                if (employee is null) return new GenericResponse { Errors = new[] { "User doesn't exist" } };
                var employeeConnections = await _context.Employees.FindAsync(request.EmployeeId);

                if (employee.Email != request.EmailAddress)
                {
                    var emailToken = await _userManager.GenerateChangeEmailTokenAsync(employee, request.EmailAddress);
                    var result = await _userManager.ChangeEmailAsync(employee, request.EmailAddress, emailToken);

                    if (!result.Succeeded)
                        return new GenericResponse { Errors = result.Errors.Select(x => x.Description) };
                }

                var changeRoleResult = await ChangeRole(employee, request.Role);
                if (!changeRoleResult.Success) return new GenericResponse { Errors = changeRoleResult.Errors };

                if (!string.IsNullOrEmpty(request.Password))
                {
                    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(employee);
                    var resetResult = await _userManager.ResetPasswordAsync(employee, resetToken, request.Password);

                    if (!resetResult.Succeeded)
                        return new GenericResponse { Errors = resetResult.Errors.Select(x => x.Description) };
                }

                employee = _context.Users.Single(x => x.Id == request.EmployeeId);

                employee.Title = request.Title;
                employee.Name = request.Name;
                employee.Surname = request.Surname;
                employee.PhoneNumber = request.PhoneNumber;
                employee.BirthCertificateNumber = request.BirthCertificateNumber;
                employee.BirthDate = request.BirthDate;
                employee.BirthPlace = request.BirthPlace;
                employee.Specialty = request.Specialty;
                employee.AddressOfPermanentResidence = request.AddressOfPermanentResidence;
                employee.Citizenship = request.Citizenship;
                employee.Gender = request.Gender;
                employee.Salary = request.Salary;
                employee.NumberOfVacationDays = request.NumberOfVacationDays;
                employee.IdCardNumber = request.IdCardNumber;
                employee.DrivingLicenceNumber = request.DrivingLicenceNumber;
                employee.HealthInsuranceCompany = request.HealthInsuranceCompany;
                employee.NumberOfChildren = request.NumberOfChildren;
                employee.FamilyStatus = request.FamilyStatus;
                employee.NameOfTheBank = request.NameOfTheBank;
                employee.AccountNumber = request.AccountNumber;
                employeeConnections.WorkPlaceID = request.WorkPlaceID;
                employeeConnections.WorkPlace = await _context.Workplaces.FindAsync(request.WorkPlaceID);

                await _context.SaveChangesAsync(cancellationToken);

                return new GenericResponse { Success = true };
            }

            private async Task<OperationResult> ChangeRole(ApplicationUser employee, Role role)
            {
                var currentRole = (await _userManager.GetRolesAsync(employee)).Single();

                if (currentRole != role.ToString() && currentRole == Role.SysAdmin.ToString())
                    return new OperationResult { Errors = new[] { "SysAdmin cannot change his own role." } };

                if (currentRole == role.ToString()) return new OperationResult { Success = true };

                await _userManager.RemoveFromRoleAsync(employee, currentRole);
                await _userManager.AddToRoleAsync(employee, role.ToString());

                switch (currentRole)
                {
                    case Roles.Employee:
                        (await _context.Employees.SingleAsync(x => x.ID == employee.Id)).HasChangedRole = true;
                        break;
                    case Roles.WorkPlaceLeader:
                        (await _context.WorkPlaceLeaders.SingleAsync(x => x.ID == employee.Id)).HasChangedRole = true;
                        break;
                    case Roles.HR_Worker:
                        (await _context.HR_Workers.SingleAsync(x => x.ID == employee.Id)).HasChangedRole = true;
                        break;
                }

                switch (role)
                {
                    case Role.Employee:
                        if (await _context.Employees.AnyAsync(x => x.ID == employee.Id))
                            (await _context.Employees.SingleAsync(x => x.ID == employee.Id)).HasChangedRole = false;
                        else
                            _context.Employees.Add(new Employee { IdentityUser = employee });
                        break;
                    case Role.WorkPlaceLeader:
                        if (await _context.WorkPlaceLeaders.AnyAsync(x => x.ID == employee.Id))
                            (await _context.WorkPlaceLeaders.SingleAsync(x => x.ID == employee.Id)).HasChangedRole = false;
                        else
                            _context.WorkPlaceLeaders.Add(new WorkPlaceLeader { IdentityUser = employee });
                        break;
                    case Role.HR_Worker:
                        if (await _context.HR_Workers.AnyAsync(x => x.ID == employee.Id))
                            (await _context.HR_Workers.SingleAsync(x => x.ID == employee.Id)).HasChangedRole = false;
                        else
                            _context.HR_Workers.Add(new HR_Worker { IdentityUser = employee });
                        break;
                    default:
                        throw new ArgumentException($"Cant switch to role {role}.");

                }

                return new OperationResult { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Invalid email address.");
                RuleFor(x => x.Name).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Surname).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Title).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Specialty).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.AddressOfPermanentResidence).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.PhoneNumber).Must(IsEmptyOrPhoneNumber).WithMessage("Invalid phone number.");
                RuleFor(x => x.Role).Must(x => x > 0 && (int)x < 4).WithMessage("Invalid role.");
                RuleFor(x => x.BirthCertificateNumber).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.BirthPlace).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Citizenship).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Salary).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.NumberOfVacationDays).Must(x => x > 0).WithMessage("Must be positive number.");
            }
            private bool IsEmptyOrPhoneNumber(string value)
            {
                if (string.IsNullOrEmpty(value)) return true;
                return Regex.IsMatch(value, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
            }
        }
    }
}
