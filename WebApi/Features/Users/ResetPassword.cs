using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Entities;

namespace WebApi.Features.Users
{
    public class ResetPassword
    {
        public class Command : IRequest<GenericResponse>
        {
            [JsonIgnore]
            public string UserId { get; set; }
            public string NewPassword { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, GenericResponse>
        {
            private UserManager<ApplicationUser> _userManager;

            public CommandHandler(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<GenericResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordChangeResult = await _userManager.ResetPasswordAsync(user, resetToken, request.NewPassword);

                return new GenericResponse
                {
                    Success = passwordChangeResult.Succeeded,
                    Errors = passwordChangeResult.Errors.Any() ? passwordChangeResult.Errors.Select(x => x.Description) : new[] { "" }
                };
            }
        }
    }
}
