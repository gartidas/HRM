using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Features.Vacations;

namespace WebApi.Controllers
{
    //[Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private IMediator _mediator;

        public VacationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Vacations.CreateVacation)]
        public async Task<ActionResult<GenericResponse>> CreateVacation([FromRoute]string employeeId, [FromBody]CreateVacation.Command command)
        {
            command.EmployeeId = employeeId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Vacations.DeleteVacation)]
        public async Task<ActionResult> DeleteVacation([FromRoute]string vacationId)
        {
            return await _mediator.Send(new DeleteVacation.Command { VacationId = vacationId })
                ? Ok()
                : BadRequest("Vacation not found or was already deleted") as ActionResult;
        }

        [HttpGet(ApiRoutes.Vacations.GetAllVacationsOfEmployee)]
        public async Task<ActionResult<GetAllVacationsOfEmployee.VacationDto>> GetAllVacationsOfEmployee([FromRoute]string employeeId)
        {
            var result = await _mediator.Send(new GetAllVacationsOfEmployee.Query { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.Vacations.SetApprovedStateOfVacation)]
        public async Task<ActionResult<GenericResponse>> SetApprovedStateOfVacation([FromRoute]string vacationId, [FromBody]SetApprovedStateOfVacation.Command command)
        {
            command.VacationId = vacationId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }
    }
}
