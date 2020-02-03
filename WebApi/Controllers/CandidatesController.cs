using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Candidates;

namespace WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = Roles.SysAdmin)]
        [HttpPost(ApiRoutes.Candidates.CreateCandidate)]
        public async Task<ActionResult<GenericResponse>> CreateCandidate([FromBody]CreateCandidate.Command request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
        [Authorize(Roles = Roles.SysAdmin)]
        [HttpGet(ApiRoutes.Candidates.GetCandidate)]
        public async Task<ActionResult<GetCandidate.Query>> GetCandidate([FromRoute]string candidateId)
        {
            var result = await _mediator.Send(new GetCandidate.Query { CandidateId = candidateId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        //[HttpGet(ApiRoutes.Candidates.GetAllCandidates)]
        //public async Task<ActionResult<PagedResponse<GetAllCandidates.CandidateDto>>> GetAllCandidates([FromQuery]GetAllCandidates.Filter filter, [FromQuery]PaginationQuery paginationQuery)
        //{
        //    var result = await _mediator.Send(new GetAllCandidates.Query { Filter = filter, PaginationQuery = paginationQuery });
        //    return Ok(result);
        //}

        [Authorize(Roles = Roles.SysAdmin)]
        [HttpPut(ApiRoutes.Candidates.EditCandidate)]
        public async Task<ActionResult<GenericResponse>> EditCandidate([FromRoute]string candidateId, [FromBody]EditCandidate.Command command)
        {
            command.CandidateId = candidateId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [Authorize(Roles = Roles.SysAdmin)]
        [HttpDelete(ApiRoutes.Candidates.DeleteCandidate)]
        public async Task<ActionResult> DeleteCandidate([FromRoute]string candidateId)
        {
            return await _mediator.Send(new DeleteCandidate.Command { CandidateId = candidateId })
                ? Ok()
                : BadRequest("Candidate not found or was already deleted") as ActionResult;
        }
    }
}
