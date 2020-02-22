using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Domain.IdentityModels;
using WebApi.Features.FormerEmployees;
using WebApi.Paging;

namespace WebApi.Controllers
{
    //[Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class FormerEmployeesController : ControllerBase
    {
        private IMediator _mediator;

        public FormerEmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.FormerEmployees.GetFormerEmployee)]
        public async Task<ActionResult<GetFormerEmployee.Query>> GetFormerEmployee([FromRoute]string formerEmployeeId)
        {
            var result = await _mediator.Send(new GetFormerEmployee.Query { FormerEmployeeId = formerEmployeeId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        [HttpGet(ApiRoutes.FormerEmployees.GetAllFormerEmployees)]
        public async Task<ActionResult<PagingResponse<GetFormerEmployee.FormerEmployeeDto>>> GetAllFormerEmployees([FromQuery]GetAllFormerEmployees.Filter filter, [FromQuery]PagingReferences pagingReferences)
        {
            var result = await _mediator.Send(new GetAllFormerEmployees.Query { Filter = filter, PagingReferences = pagingReferences });
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.FormerEmployees.DeleteFormerEmployee)]
        public async Task<ActionResult> DeleteFormerEmployee([FromRoute]string formerEmployeeId)
        {
            return await _mediator.Send(new DeleteFormerEmployee.Command { FormerEmployeeId = formerEmployeeId })
                ? Ok()
                : BadRequest("Former employee not found or was already deleted") as ActionResult;
        }
    }
}
