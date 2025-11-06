using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMapaCRUEH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbulanciasController : ControllerBase
    {
        private readonly IApiHelper _apiHelper;
        private readonly ExtranetServiceOptions _options;
        private readonly IEXSession _session;
        public AmbulanciasController(IEXSession session, IApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _options = configuration.GetSection("ExtranetServices").Get<ExtranetServiceOptions>();
            _session = session;

        }
        [HttpPost]
        [Route("ObtenerListadoAmbulancias")]
        public async Task<IActionResult> ObtenerListadoAmbulancias(ConsultarAmbulaciasDto consultarAmbulaciasDto)
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
