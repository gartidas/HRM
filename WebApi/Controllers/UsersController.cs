using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Users;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize(Roles = Roles.SysAdmin, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Users.Login)]
        public async Task<ActionResult<Login.CommandResponse>> Login([FromBody]Login.Command request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Users.ChangePassword)]
        public async Task<ActionResult<GenericResponse>> ChangePassword([FromBody]ChangePassword.Command command)
        {
            command.UserId = User.Claims.Single(x => x.Type == "id").Value;
            var result = await _mediator.Send(command);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost(ApiRoutes.Users.ResetPassword)]
        public async Task<ActionResult<GenericResponse>> ResetPassword([FromRoute]string userId, [FromBody]ResetPassword.Command command)
        {
            command.UserId = userId;
            var result = await _mediator.Send(command);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }

}
