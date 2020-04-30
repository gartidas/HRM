using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.Documentation;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private IMediator _mediator;

        public DocumentationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Documentation.CreateDocumentForEmployee)]
        public async Task<ActionResult<GenericResponse>> CreateDocumentForEmployee([FromRoute]string employeeId, [FromBody]CreateDocumentForEmployee.Command command)
        {
            command.EmployeeId = employeeId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost(ApiRoutes.Documentation.CreateDocumentForCandidate)]
        public async Task<ActionResult<GenericResponse>> CreateDocumentForCandidate([FromRoute]string candidateId, [FromBody]CreateDocumentForCandidate.Command command)
        {
            command.CandidateId = candidateId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Documentation.DeleteDocument)]
        public async Task<ActionResult> DeleteDocument([FromRoute]string documentId)
        {
            return await _mediator.Send(new DeleteDocument.Command { DocumentId = documentId })
                ? Ok()
                : BadRequest("File not found or was already deleted") as ActionResult;
        }

        [HttpGet(ApiRoutes.Documentation.GetAllDocumentsOfEmployee)]
        public async Task<ActionResult<GetDocument.DocumentDto>> GetAllDocumentsOfEmployee([FromRoute]string employeeId)
        {
            var result = await _mediator.Send(new GetAllDocumentsOfEmployee.Query { EmployeeId = employeeId });
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Documentation.GetAllDocumentsOfCandidate)]
        public async Task<ActionResult<GetDocument.DocumentDto>> GetAllDocumentsOfCandidate([FromRoute]string candidateId)
        {
            var result = await _mediator.Send(new GetAllDocumentsOfCandidate.Query { CandidateId = candidateId });
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Documentation.GetAllDocumentsOfFormerEmployee)]
        public async Task<ActionResult<GetDocument.DocumentDto>> GetAllDocumentsOfFormerEmployee([FromRoute]string formerEmployeeId)
        {
            var result = await _mediator.Send(new GetAllDocumentsOfFormerEmployee.Query { FormerEmployeeId = formerEmployeeId });
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Documentation.GetDocument)]
        public async Task<ActionResult<GetDocument.Query>> GetDocument([FromRoute]string documentId)
        {
            var result = await _mediator.Send(new GetDocument.Query { DocumentId = documentId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }
    }
}
