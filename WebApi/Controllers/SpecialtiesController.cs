using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Specialties;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.WorkPlaceLeader, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private IMediator _mediator;

        public SpecialtiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Specialties.CreateSpecialty)]
        public async Task<ActionResult<GenericResponse>> CreateSpecialty([FromRoute]string workPlaceId, [FromBody]CreateSpecialty.Command command)
        {
            command.WorkplaceID = workPlaceId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Specialties.DeleteSpecialty)]
        public async Task<ActionResult> DeleteSpecialty([FromRoute]string specialtyId)
        {
            return await _mediator.Send(new DeleteSpecialty.Command { SpecialtyId = specialtyId })
                ? Ok()
                : BadRequest("Specialty not found or was already deleted") as ActionResult;
        }

        [HttpGet(ApiRoutes.Specialties.GetAllSpecialtesOfWorkPlace)]
        public async Task<ActionResult<GetAllSpecialtesOfWorkPlace.SpecialtyDto>> GetAllSpecialtesOfWorkPlace([FromRoute]string workPlaceId)
        {
            var result = await _mediator.Send(new GetAllSpecialtesOfWorkPlace.Query { WorkPlaceId = workPlaceId });
            return Ok(result);
        }
    }
}
