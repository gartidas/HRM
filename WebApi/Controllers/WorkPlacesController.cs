using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Features.WorkPlaces;

namespace WebApi.Controllers
{
    //[Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

    }
}
