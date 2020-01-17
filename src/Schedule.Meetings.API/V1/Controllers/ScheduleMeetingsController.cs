using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Meetings.Application.Interfaces;
using Schedule.Meetings.Application.Models;
using Schedule.Meetings.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Schedule.Meetings.API.V1.Controllers
{
  
    [ApiController, ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
    public class ScheduleMeetingsController : Controller
    {
        private readonly IScheduleMeetingsAppService _scheduleMeetingsAppService;
        private readonly IRoomsAppService _roomsAppService;

        public ScheduleMeetingsController(IScheduleMeetingsAppService scheduleMeetingsAppService, IRoomsAppService roomsAppService)
        {
            _scheduleMeetingsAppService = scheduleMeetingsAppService;
            _roomsAppService = roomsAppService;
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Criar agendamento de reunião")]
        [SwaggerResponse(200, "Sucesso, retorna objeto ResponseModel", typeof(ResponseModel))]
        public ActionResult<ResponseModel> Schedule([FromBody] ScheduleMeetingsModel model)
        {
            try
            {
                return Ok(_scheduleMeetingsAppService.Schedule(model));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("rooms")]
        [SwaggerOperation(Summary = "Obter salas de reuniões")]
        [SwaggerResponse(200, "Sucesso, retorna objeto Rooms", typeof(Rooms))]
        public ActionResult<Rooms> GetAllRooms()
        {
            try
            {
                return Ok(_roomsAppService.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
