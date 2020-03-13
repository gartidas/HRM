using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Features.Bonuses;

namespace WebApi.Controllers
{
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

        [HttpGet(ApiRoutes.Bonuses.GetAllBonusesOfEmployee)]
        public async Task<ActionResult<GetAllBonusesOfEmployee.BonusDto>> GetAllBonusesOfEmployee([FromRoute]string employeeId)
        {
            var result = await _mediator.Send(new GetAllBonusesOfEmployee.Query { EmployeeId = employeeId });
            return Ok(result);
        }
    }
}
