using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Domain.IdentityModels;
using WebApi.Services;

namespace WebApi.Features.Employees
{
    public class Hire
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string CandidateId { get; set; }
            public string Password { get; set; }
            public string BirthCertificateNumber { get; set; }
            public DateTime BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string Citizenship { get; set; }
            public bool Gender { get; set; }
            public double Salary { get; set; }
            public int NumberOfVacationDays { get; set; }
            public string WorkPlaceID { get; set; }
            public Role Role { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private Context _context;
            private IIdentityService _identityService;
            private IMapper _mapper;

            public CommandHandler(Context context, IIdentityService identityService, IMapper mapper)
            {
                _context = context;
                _identityService = identityService;
                _mapper = mapper;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var candidate = await _context.Candidates.SingleOrDefaultAsync(x => x.ID == request.CandidateId);
                if (candidate is null) return new GenericResponse { Errors = new[] { "Candidate does not exist." } };
                candidate.Status = Entities.Status.Hired;

                var employee = new RegisterModel
                {
                    Title = candidate.Title,
                    Name = candidate.Name,
                    Surname = candidate.Surname,
                    EmailAddress = candidate.Email,
                    Password = request.Password,
                    PhoneNumber = candidate.PhoneNumber,
                    BirthCertificateNumber = request.BirthCertificateNumber,
                    BirthDate = request.BirthDate,
                    BirthPlace = request.BirthPlace,
                    Specialty = candidate.Specialty,
                    AddressOfPermanentResidence = candidate.Address,
                    Citizenship = request.Citizenship,
                    Gender = request.Gender,
                    Salary = request.Salary,
                    NumberOfVacationDays = request.NumberOfVacationDays,
                    WorkPlaceID = request.WorkPlaceID,
                    Role = request.Role,
                    Documentation = candidate.Documentation
                };
                var result = await _identityService.RegisterAsync(_mapper.Map<RegisterModel>(employee));
                await _context.SaveChangesAsync();
                return _mapper.Map<GenericResponse>(result);
            }
        }



        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Role).Must(x => x > 0 && (int)x < 3).WithMessage("Invalid role.");
                RuleFor(x => x.BirthCertificateNumber).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.BirthPlace).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Citizenship).Must(x => x.Length > 1 && x.Length < 30).WithMessage("Must have minimum of 2 chars and maximum of 29 chars.");
                RuleFor(x => x.Salary).Must(x => x > 0).WithMessage("Must be positive number.");
                RuleFor(x => x.NumberOfVacationDays).Must(x => x > 0).WithMessage("Must be positive number.");
            }
        }
    }
}
