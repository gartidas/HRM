using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Features.Users;

namespace WebApi.Controllers
{
    [ApiController]
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

        [HttpPost(ApiRoutes.Users.ChangePassword)]
        public async Task<ActionResult<GenericResponse>> ChangePassword([FromBody]ChangePassword.Command command)
        {
            var userId = User.Claims.Single(x => x.Type == "id").Value;
            command.UserId = userId;
            var result = await _mediator.Send(command);

            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }

}
