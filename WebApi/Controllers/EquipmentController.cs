using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Domain.IdentityModels;
using WebApi.Features.EquipmentItems;

namespace WebApi.Controllers
{
    [Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private IMediator _mediator;

        public EquipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiRoutes.Equipment.CreateEquipment)]
        public async Task<ActionResult<GenericResponse>> CreateEquipment([FromRoute]string employeeId, [FromBody]CreateEquipment.Command command)
        {
            command.EmployeeId = employeeId;
            var result = await _mediator.Send(command);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Equipment.DeleteEquipment)]
        public async Task<ActionResult> DeleteEquipment([FromRoute]string equipmentId)
        {
            return await _mediator.Send(new DeleteEquipment.Command { EquipmentId = equipmentId })
                ? Ok()
                : BadRequest("Item not found or was already deleted") as ActionResult;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Equipment.GetAllEquipmentOfEmployee)]
        public async Task<ActionResult<GetAllEquipmentOfEmployee.EquipmentDto>> GetAllEquipmentOfEmployee()
        {
            var result = await _mediator.Send(new GetAllEquipmentOfEmployee.Query { EmployeeId = User.Claims.Single(x => x.Type == "id").Value });
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Equipment.GetEquipmentStatusOfEmployee)]
        public async Task<ActionResult<int>> GetEquipmentStatusOfEmployee()
        {
            var result = await _mediator.Send(new GetEquipmentStatusOfEmployee.Query { EmployeeId = User.Claims.Single(x => x.Type == "id").Value });
            return Ok(result);
        }

        [HttpPut(ApiRoutes.Equipment.SetEquipmentStatusOfEmployee)]
        public async Task<ActionResult<GenericResponse>> SetEquipmentStatusOfEmployee([FromRoute]string employeeId, [FromBody]SetEquipmentStatusOfEmployee.Command command)
        {
            command.EmployeeId = employeeId;
            var result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result) as ActionResult;
        }
    }
}
