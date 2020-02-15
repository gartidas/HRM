using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Employees;
using WebApi.Paging;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Employees.Hire)]
        public async Task<ActionResult<GenericResponse>> Hire([FromRoute]string candidateId, [FromBody]Hire.Command request)
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
    }
}
