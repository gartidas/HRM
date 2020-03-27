using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Bonuses;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class BonusesController : ControllerBase
    {
        private IMediator _mediator;

        public BonusesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Bonuses.CreateBonus)]
        public async Task<ActionResult<GenericResponse>> CreateBonus([FromRoute]string employeeId, [FromRoute]string hR_WorkerId, [FromBody]CreateBonus.Command command)
        {
            command.EmployeeID = employeeId;
            command.HR_WorkerID = hR_WorkerId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Bonuses.DeleteBonus)]
        public async Task<ActionResult> DeleteBonus([FromRoute]string bonusId)
        {
            return await _mediator.Send(new DeleteBonus.Command { BonusId = bonusId })
                ? Ok()
                : BadRequest("Granted bonus not found or was already deleted") as ActionResult;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Bonuses.GetAllBonusesOfEmployee)]
        public async Task<ActionResult<GetAllBonusesOfEmployee.BonusDto>> GetAllBonusesOfEmployee()
        {
            var result = await _mediator.Send(new GetAllBonusesOfEmployee.Query { EmployeeId = User.Claims.Single(x => x.Type == "id").Value });
            return Ok(result);
        }
    }
}
