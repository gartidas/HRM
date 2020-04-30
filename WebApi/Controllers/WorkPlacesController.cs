using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.WorkPlaces;
using WebApi.Paging;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class WorkPlacesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkPlacesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.WorkPlaces.CreateWorkPlace)]
        public async Task<ActionResult<GenericResponse>> CreateWorkPlace([FromBody]CreateWorkPlace.Command request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet(ApiRoutes.WorkPlaces.GetWorkPlace)]
        public async Task<ActionResult<GetWorkPlace.Query>> GetWorkPlace([FromRoute]string workPlaceId)
        {
            var result = await _mediator.Send(new GetWorkPlace.Query { WorkPlaceId = workPlaceId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        [HttpPut(ApiRoutes.WorkPlaces.EditWorkPlace)]
        public async Task<ActionResult<GenericResponse>> EditWorkPlace([FromRoute]string workPlaceId, [FromBody]EditWorkPlace.Command command)
        {
            command.WorkPlaceId = workPlaceId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpDelete(ApiRoutes.WorkPlaces.DeleteWorkPlace)]
        public async Task<ActionResult> DeleteWorkPlace([FromRoute]string workPlaceId)
        {
            return await _mediator.Send(new DeleteWorkPlace.Command { WorkPlaceId = workPlaceId })
                ? Ok()
                : BadRequest("Error occured while deleting workplace") as ActionResult;
        }

        [HttpGet(ApiRoutes.WorkPlaces.GetAllWorkPlaces)]
        public async Task<ActionResult<PagingResponse<GetAllWorkPlaces.WorkPlaceDto>>> GetAllWorkPlaces([FromQuery]GetAllWorkPlaces.Filter filter, [FromQuery]PagingReferences pagingReferences)
        {
            var result = await _mediator.Send(new GetAllWorkPlaces.Query { Filter = filter, PagingReferences = pagingReferences });
            return Ok(result);
        }
    }
}
