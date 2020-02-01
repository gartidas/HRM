using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Services;

namespace WebApi.Features.Users
{
    public class Register
    {
        public class Command : IRequest<GenericResponse>
        {
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
            public RegisterableRole Role { get; set; }

        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private IIdentityService _identityService;
            private IMapper _mapper;

            public CommandHandler(IIdentityService identityService, IMapper mapper)
            {
                _identityService = identityService;
                _mapper = mapper;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _identityService.RegisterAsync(_mapper.Map<RegisterModel>(request));
                return _mapper.Map<GenericResponse>(result);
            }
        }

        public enum RegisterableRole
        {
            HR_Worker = 1,
            WorkPlaceLeader = 2,
            Employee = 3
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Invalid email address.");
                RuleFor(x => x.Role).Must(x => x > 0 && (int)x < 4).WithMessage("Invalid role.");
                RuleFor(x => x.Name).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Surname).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.BirthCertificateNumber).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Title).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.BirthPlace).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Specialty).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.AddressOfPermanentResidence).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Citizenship).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Salary).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.NumberOfVacationDays).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.PhoneNumber).Must(IsEmptyOrPhoneNumber).WithMessage("Invalid phone number.");
            }

            private bool IsEmptyOrPhoneNumber(string value)
            {
                if (string.IsNullOrEmpty(value)) return true;
                return Regex.IsMatch(value, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
            }
        }
    }
}
