using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Vacations;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.WorkPlaceLeader, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private IMediator _mediator;

        public VacationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Vacations.CreateVacation)]
        public async Task<ActionResult<GenericResponse>> CreateVacation([FromBody]CreateVacation.Command command)
        {
            command.EmployeeId = User.Claims.Single(x => x.Type == "id").Value;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Vacations.DeleteVacation)]
        public async Task<ActionResult> DeleteVacation([FromRoute]string dateAndTime)
        {
            return await _mediator.Send(new DeleteVacation.Command { EmployeeId = User.Claims.Single(x => x.Type == "id").Value, DateAndTime = dateAndTime })
                ? Ok()
                : BadRequest("Vacation not found or was already deleted") as ActionResult;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Vacations.GetAllVacationsOfEmployee)]
        public async Task<ActionResult<GetAllVacationsOfEmployee.VacationDto>> GetAllVacationsOfEmployee()
        {
            var employeeId = User.Claims.Single(x => x.Type == "id").Value;
            var result = await _mediator.Send(new GetAllVacationsOfEmployee.Query { EmployeeId = employeeId });

            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        [HttpGet(ApiRoutes.Vacations.GetAllVacationsOfSelectedEmployee)]
        public async Task<ActionResult<GetAllVacationsOfEmployee.VacationDto>> GetAllVacationsOfSelectedEmployee([FromRoute] string employeeId)
        {
            var result = await _mediator.Send(new GetAllVacationsOfEmployee.Query { EmployeeId = employeeId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
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
