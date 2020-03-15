using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Data;
using WebApi.Domain.IdentityModels;
using WebApi.Entities;
using WebApi.Entities.Joins;

namespace WebApi.Features.CorporateEvents
{
    public class CreateCorporateEvent
    {
        public class Command : IRequest<GenericResponse>
        {
            public IEnumerable<string> WorkPlaceLeaderIds { get; set; }
            public string Name { get; set; }
            public string RequestDescription { get; set; }
            public string Location { get; set; }
            public DateTime DateAndTime { get; set; }
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
                if (await _context.CorporateEvents.AnyAsync(x => x.Name == request.Name && x.Location == request.Location && x.DateAndTime == request.DateAndTime))
                    return new GenericResponse { Errors = new[] { $"Event already exists." } };

                var corporateEvent = new CorporateEvent
                {
                    Name = request.Name,
                    RequestDescription = request.RequestDescription,
                    Location = request.Location,
                    DateAndTime = request.DateAndTime
                };

                await _context.AddAsync(corporateEvent);

                await _context.SaveChangesAsync();

                corporateEvent = _context.CorporateEvents.SingleOrDefault(x => x.Name == request.Name && x.Location == request.Location && x.DateAndTime == request.DateAndTime);

                var workPlaceLeaders = _context.WorkPlaceLeaders.Where(x => request.WorkPlaceLeaderIds.Contains(x.ID));

                foreach (var workPlaceLeader in workPlaceLeaders)
                {
                    var join = new WorkPlaceLeaderCorporateEvent
                    {
                        CorporateEvent = corporateEvent,
                        WorkPlaceLeader = workPlaceLeader
                    };

                    await _context.AddAsync(join);
                }

                await _context.SaveChangesAsync();

                return new GenericResponse { Success = true };
            }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            private UserManager<ApplicationUser> _userManager;

            public CommandValidator(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;

                RuleForEach(x => x.WorkPlaceLeaderIds).MustAsync(BeWorkPlaceLeader).WithMessage("One or more ids does not belong to work place leaders.");
                RuleFor(x => x.WorkPlaceLeaderIds).Must(x => x.Any()).WithMessage("Must contain at least one work place leader.");
                RuleFor(x => x.Name).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.Location).Must(x => x.Length > 0).WithMessage("Is Required.");
                RuleFor(x => x.DateAndTime).Must(x => x > DateTime.UtcNow).WithMessage("Date must be in the future");
            }

            private async Task<bool> BeWorkPlaceLeader(string id, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user is null) return false;

                return (await _userManager.GetRolesAsync(user)).Single() == Roles.WorkPlaceLeader;
            }

        }
    }
}
