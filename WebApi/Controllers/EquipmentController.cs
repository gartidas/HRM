using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Controllers.Responses;
using WebApi.Features.EquipmentItems;

namespace WebApi.Controllers
{
    //[Authorize(Roles = Roles.SysAdmin + "," + Roles.HR_Worker, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet(ApiRoutes.Equipment.GetAllEquipmentOfEmployee)]
        public async Task<ActionResult<GetAllEquipmentOfEmployee.EquipmentDto>> GetAllEquipmentOfEmployee([FromRoute]string employeeId)
        {
            var result = await _mediator.Send(new GetAllEquipmentOfEmployee.Query { EmployeeId = employeeId });
            return Ok(result);
        }
    }
}
