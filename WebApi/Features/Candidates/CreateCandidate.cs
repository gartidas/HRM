using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Candidates
{
    public class CreateCandidate
    {
        public class Command : IRequest<GenericResponse>
        {
            public string Title { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Education { get; set; }
            public string Specialty { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public double RequestedSalary { get; set; }
            public int Evaluation { get; set; }
            public Status Status { get; set; }
            public string AdditionalInfo { get; set; }
            public List<Document> Documentation { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private Context _context;

            public CommandHandler(Context context)
            {
                _context = context;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                if (await _context.Candidates.AnyAsync(x => x.Email == request.Email))
                    return new GenericResponse { Errors = new[] { $"Candidate with email {request.Email} already exists." } };

                var candidate = new Candidate
                {
                    Title = request.Title,
                    Name = request.Name,
                    Surname = request.Surname,
                    Education = request.Education,
                    Specialty = request.Specialty,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    Address = request.Address,
                    RequestedSalary = request.RequestedSalary,
                    Evaluation = request.Evaluation,
                    Status = request.Status,
                    AdditionalInfo = request.AdditionalInfo,
                    Documentation = request.Documentation
                };

                await _context.Candidates.AddAsync(candidate);
                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address.");
                RuleFor(x => x.Name).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Surname).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Title).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Specialty).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Address).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.RequestedSalary).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.PhoneNumber).Must(IsEmptyOrPhoneNumber).WithMessage("Invalid phone number.");
                RuleFor(x => x.Status).Must(x => x >= 0 && (int)x <= 5).WithMessage("Invalid status.");
                RuleFor(x => x.Evaluation).Must(x => x >= 0 && (int)x <= 10).WithMessage("Must be between 0 and 10.");
                RuleFor(x => x.Education).Must(x => x.Length > 9 && x.Length < 201).WithMessage("Must have minimum of 10 chars and maximum of 200 chars.");
            }

            private bool IsEmptyOrPhoneNumber(string value)
            {
                if (string.IsNullOrEmpty(value)) return true;
                return Regex.IsMatch(value, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
            }
        }
    }
}
