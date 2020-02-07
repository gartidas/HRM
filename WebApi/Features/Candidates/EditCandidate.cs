using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Entities;

namespace WebApi.Features.Candidates
{
    public class EditCandidate
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string CandidateId { get; set; }
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
                var candidate = await _context.Candidates.SingleOrDefaultAsync(x => x.ID == request.CandidateId, cancellationToken);

                if (candidate is null)
                    return new GenericResponse { Errors = new[] { $"Candidate with id {request.CandidateId} does not exist." } };

                if (await _context.Candidates.AnyAsync(x => x.Email == request.Email && x.Email != candidate.Email))
                    return new GenericResponse { Errors = new[] { $"Candidate with email {request.Email} already exists." } };

                candidate.Title = request.Title;
                candidate.Name = request.Name;
                candidate.Surname = request.Surname;
                candidate.Education = request.Education;
                candidate.Specialty = request.Specialty;
                candidate.PhoneNumber = request.PhoneNumber;
                candidate.Email = request.Email;
                candidate.Address = request.Address;
                candidate.RequestedSalary = request.RequestedSalary;
                candidate.Evaluation = request.Evaluation;
                candidate.Status = request.Status;
                candidate.AdditionalInfo = request.AdditionalInfo;
                candidate.Documentation = request.Documentation;

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
