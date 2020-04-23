using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.CorporateEvents;
using WebApi.Paging;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker + "," + Roles.WorkPlaceLeader, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CorporateEventsController : ControllerBase
    {
        private IMediator _mediator;

        public CorporateEventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.CorporateEvents.CreateCorporateEvent)]
        public async Task<ActionResult<GenericResponse>> CreateCorporateEvent([FromBody]CreateCorporateEvent.Command command)
        {
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut(ApiRoutes.CorporateEvents.EditCorporateEvent)]
        public async Task<ActionResult<GenericResponse>> EditCorporateEvent([FromRoute]string corporateEventId, [FromBody]EditCorporateEvent.Command command)
        {
            command.CorporateEventId = corporateEventId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpDelete(ApiRoutes.CorporateEvents.DeleteCorporateEvent)]
        public async Task<ActionResult> DeleteCorporateEvent([FromRoute]string corporateEventId)
        {
            return await _mediator.Send(new DeleteCorporateEvent.Command { CorporateEventId = corporateEventId })
                ? Ok()
                : BadRequest("Event not found or was already deleted") as ActionResult;
        }

        [HttpGet(ApiRoutes.CorporateEvents.GetCorporateEvent)]
        public async Task<ActionResult<GetCorporateEvent.Query>> GetCorporateEvent([FromRoute]string corporateEventId)
        {
            var result = await _mediator.Send(new GetCorporateEvent.Query { CorporateEventId = corporateEventId });
            return result is null ? NotFound() : Ok(result) as ActionResult;
        }

        [HttpGet(ApiRoutes.CorporateEvents.GetAllCorporateEvents)]
        public async Task<ActionResult<PagingResponse<GetCorporateEvent.CorporateEventDto>>> GetAllCorporateEvents([FromQuery]GetAllCorporateEvents.Filter filter, [FromQuery]PagingReferences pagingReferences)
        {
            var result = await _mediator.Send(new GetAllCorporateEvents.Query { Filter = filter, PagingReferences = pagingReferences });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.CorporateEvents.AssignEmployeesToCorporateEvent)]
        public async Task<ActionResult<GenericResponse>> AssignEmployeesToCorporateEvent([FromRoute]string corporateEventId, [FromBody]AssignEmployeesToCorporateEvent.Command command)
        {
            command.CorporateEventId = corporateEventId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpPut(ApiRoutes.CorporateEvents.RemoveEmployeesFromCorporateEvent)]
        public async Task<ActionResult<GenericResponse>> RemoveEmployeesFromCorporateEvent([FromRoute]string corporateEventId, [FromBody]RemoveEmployeesFromCorporateEvent.Command command)
        {
            command.CorporateEventId = corporateEventId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpPut(ApiRoutes.CorporateEvents.AssignWorkPlaceLeadersToCorporateEvent)]
        public async Task<ActionResult<GenericResponse>> AssignWorkPlaceLeadersToCorporateEvent([FromRoute]string corporateEventId, [FromBody]AssignWorkPlaceLeadersToCorporateEvent.Command command)
        {
            command.CorporateEventId = corporateEventId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [HttpPut(ApiRoutes.CorporateEvents.RemoveWorkPlaceLeadersFromCorporateEvent)]
        public async Task<ActionResult<GenericResponse>> RemoveWorkPlaceLeadersFromCorporateEvent([FromRoute]string corporateEventId, [FromBody]RemoveWorkPlaceLeadersFromCorporateEvent.Command command)
        {
            command.CorporateEventId = corporateEventId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.CorporateEvents.GetAllCorporateEventsOfEmployee)]
        public async Task<ActionResult<GetAllCorporateEventsOfEmployee.CorporateEventDto>> GetAllCorporateEventsOfEmployee()
        {
            var employeeId = User.Claims.Single(x => x.Type == "id").Value;
            var result = await _mediator.Send(new GetAllCorporateEventsOfEmployee.Query { EmployeeId = employeeId });

            return result is null ? NotFound() : Ok(result) as ActionResult;
        }


        [HttpGet(ApiRoutes.CorporateEvents.GetAllCorporateEventsOfWorkPlace)]
        public async Task<ActionResult<GetAllCorporateEventsOfWorkPlace.CorporateEventDto>> GetAllCorporateEventsOfWorkPlace()
        {
            var workPlaceLeaderId = User.Claims.Single(x => x.Type == "id").Value;
            var result = await _mediator.Send(new GetAllCorporateEventsOfWorkPlace.Query { WorkPlaceLeaderId = workPlaceLeaderId });

            return result is null ? NotFound() : Ok(result) as ActionResult;
        }
    }
}
