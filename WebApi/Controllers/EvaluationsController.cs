using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Evaluations;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private IMediator _mediator;

        public EvaluationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Evaluations.CreateEvaluation)]
        public async Task<ActionResult<GenericResponse>> CreateEvaluation([FromRoute]string employeeId, [FromRoute]string hR_WorkerId, [FromBody]CreateEvaluation.Command command)
        {
            command.EmployeeID = employeeId;
            command.HR_WorkerID = hR_WorkerId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Evaluations.DeleteEvaluation)]
        public async Task<ActionResult> DeleteEvaluation([FromRoute]string evaluationId)
        {
            return await _mediator.Send(new DeleteEvaluation.Command { EvaluationId = evaluationId })
                ? Ok()
                : BadRequest("Evaluation not found or was already deleted") as ActionResult;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Evaluations.GetAllEvaluationsOfEmployee)]
        public async Task<ActionResult<GetAllEvaluationsOfEmployee.EvaluationDto>> GetAllEvaluationsOfEmployee()
        {
            var result = await _mediator.Send(new GetAllEvaluationsOfEmployee.Query { EmployeeId = User.Claims.Single(x => x.Type == "id").Value });
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Evaluations.GetAllEvaluationsOfSelectedEmployee)]
        public async Task<ActionResult<GetAllEvaluationsOfEmployee.EvaluationDto>> GetAllEvaluationsOfSelectedEmployee([FromRoute]string employeeId)
        {
            var result = await _mediator.Send(new GetAllEvaluationsOfEmployee.Query { EmployeeId = employeeId });
            return Ok(result);
        }
    }
}
