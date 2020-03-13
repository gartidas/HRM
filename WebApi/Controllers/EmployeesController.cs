using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Features.Employees;
using WebApi.Paging;

namespace WebApi.Controllers
{
    //[Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Employees.HireEmployee)]
        public async Task<ActionResult<GenericResponse>> HireEmployee([FromRoute]string candidateId, [FromBody]HireEmployee.Command request)
        {
            request.CandidateId = candidateId;
            var result = await _mediator.Send(request);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Employees.GetEmployee)]
        public async Task<ActionResult<GetEmployee.Query>> GetEmployee([FromRoute]string employeeId)
        {
            var result = await _mediator.Send(new GetEmployee.Query { EmployeeId = employeeId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        [HttpGet(ApiRoutes.Employees.GetAllEmployees)]
        public async Task<ActionResult<PagingResponse<GetEmployee.EmployeeDto>>> GetAllEmployees([FromQuery]GetAllEmployees.Filter filter, [FromQuery]PagingReferences pagingReferences)
        {
            var result = await _mediator.Send(new GetAllEmployees.Query { Filter = filter, PagingReferences = pagingReferences });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.Employees.EditEmployee)]
        public async Task<ActionResult<GenericResponse>> EditEmployee([FromRoute]string employeeId, [FromBody]EditEmployee.Command command)
        {
            command.EmployeeId = employeeId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpDelete(ApiRoutes.Employees.FireEmployee)]
        public async Task<ActionResult<GenericResponse>> FireEmployee([FromRoute]string employeeId, [FromRoute]string hR_WorkerId, [FromBody]FireEmployee.Command command)
        {
            command.EmployeeId = employeeId;
            command.HR_WorkerID = hR_WorkerId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
