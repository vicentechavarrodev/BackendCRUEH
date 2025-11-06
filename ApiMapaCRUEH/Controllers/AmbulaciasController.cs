using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiMapaCRUEH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbulaciasController : ControllerBase
    {
        private readonly IApiHelper _apiHelper;
        private readonly ExtranetServiceOptions _options;
        private readonly IEXSession _session;
        public AmbulaciasController(ILogger<WeatherForecastController> logger, IEXSession session, IApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _options = configuration.GetSection("ExtranetServices").Get<ExtranetServiceOptions>();
            _session = session;

        }
        [HttpPost]
        [Route("ObtenerListadoAmbulancias")]
        public async Task<IActionResult> ObtenerListadoAmbulancias([FromForm] ConsultarAmbulaciasDto consultarAmbulaciasDto)
        {
            var response = await _apiHelper.Post<ConsultarAmbulaciasDto, Ambulancia>(_options.ApiEextranetBaseUrl, _options.ObtenerListaAmbulanciasMonitoreo, "", "", _session.ObtenerHeaders(), consultarAmbulaciasDto, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

      

    }
}
