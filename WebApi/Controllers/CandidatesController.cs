﻿using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Candidates;
using WebApi.Paging;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Candidates.CreateCandidate)]
        public async Task<ActionResult<GenericResponse>> CreateCandidate([FromBody]CreateCandidate.Command command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Candidates.GetCandidate)]
        public async Task<ActionResult<GetCandidate.Query>> GetCandidate([FromRoute]string candidateId)
        {
            var result = await _mediator.Send(new GetCandidate.Query { CandidateId = candidateId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        [HttpGet(ApiRoutes.Candidates.GetAllCandidates)]
        public async Task<ActionResult<PagingResponse<GetCandidate.CandidateDto>>> GetAllCandidates([FromQuery]GetAllCandidates.Filter filter, [FromQuery]PagingReferences pagingReferences)
        {
            var result = await _mediator.Send(new GetAllCandidates.Query { Filter = filter, PagingReferences = pagingReferences });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.Candidates.EditCandidate)]
        public async Task<ActionResult<GenericResponse>> EditCandidate([FromRoute]string candidateId, [FromBody]EditCandidate.Command command)
        {
            command.CandidateId = candidateId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpDelete(ApiRoutes.Candidates.DeleteCandidate)]
        public async Task<ActionResult> DeleteCandidate([FromRoute]string candidateId)
        {
            return await _mediator.Send(new DeleteCandidate.Command { CandidateId = candidateId })
                ? Ok()
                : BadRequest("Candidate not found or was already deleted") as ActionResult;
        }
    }
}
