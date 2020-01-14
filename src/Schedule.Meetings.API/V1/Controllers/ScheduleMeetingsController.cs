using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Meetings.Application.Interfaces;
using Schedule.Meetings.Application.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Schedule.Meetings.API.V1.Controllers
{
    [ApiController, ApiVersion("1.0"), Route("v{version:apiVersion}/[controller]")]
    public class ScheduleMeetingsController : Controller
    {
        private readonly IScheduleMeetingsAppService _scheduleMeetingsAppService;

        public ScheduleMeetingsController(IScheduleMeetingsAppService scheduleMeetingsAppService)
        {
            _scheduleMeetingsAppService = scheduleMeetingsAppService;
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
    }
}
