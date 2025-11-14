using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMapaCRUEH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {

        private readonly IApiHelper _apiHelper;
        private readonly ExtranetServiceOptions _options;
        private readonly IEXSession _session;
        public EventosController(IEXSession session, IApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _options = configuration.GetSection("ExtranetServices").Get<ExtranetServiceOptions>();
            _session = session;

        }
        [HttpPost]
        [Route("ObtenerListaMediosRecepcion")]
        public async Task<IActionResult> ObtenerListaMediosRecepcion()
        {
            var response = await _apiHelper.Post<object, ItemLista>(_options.ApiEextranetBaseUrl, _options.ObtenerListaMediosRecepcion, "", "", _session.ObtenerHeaders(), null, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

        [HttpPost]
        [Route("ObtenerListaSectoresReportantes")]
        public async Task<IActionResult> ObtenerListaSectoresReportantes()
        {
            var response = await _apiHelper.Post<object, ItemLista>(_options.ApiEextranetBaseUrl, _options.ObtenerListaSectoresReportantes, "", "", _session.ObtenerHeaders(), null, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

        [HttpPost]
        [Route("ObtenerListaTiposEvento")]
        public async Task<IActionResult> ObtenerListaTiposEvento()
        {
            var response = await _apiHelper.Post<object, ItemLista>(_options.ApiEextranetBaseUrl, _options.ObtenerListaTiposEvento, "", "", _session.ObtenerHeaders(), null, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

        [HttpPost]
        [Route("ObtenerListaEventos")]
        public async Task<IActionResult> ObtenerListaEventos(ParamsObtenerListaEventos paramsObtenerListaEventos)
        {
            var response = await _apiHelper.Post<ParamsObtenerListaEventos, ItemLista>(_options.ApiEextranetBaseUrl, _options.ObtenerListaEventos, "", "", _session.ObtenerHeaders(), paramsObtenerListaEventos, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

        [HttpPost]
        [Route("ObtenerListaTiposTrauma")]
        public async Task<IActionResult> ObtenerListaTiposTrauma()
        {
            var response = await _apiHelper.Post<object, ItemLista>(_options.ApiEextranetBaseUrl, _options.ObtenerListaTiposTrauma, "", "", _session.ObtenerHeaders(), null, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

        [HttpPost]
        [Route("ObtenerListaRolesTransito")]
        public async Task<IActionResult> ObtenerListaRolesTransito()
        {
            var response = await _apiHelper.Post<object, RespuestaNombreDescripcion>(_options.ApiEextranetBaseUrl, _options.ObtenerListaRolesTransito, "", "", _session.ObtenerHeaders(), null, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

        [HttpPost]
        [Route("ObtenerListaMecanismosLesion")]
        public async Task<IActionResult> ObtenerListaMecanismosLesion()
        {
            var response = await _apiHelper.Post<object, RespuestaNombreDescripcion>(_options.ApiEextranetBaseUrl, _options.ObtenerListaMecanismosLesion, "", "", _session.ObtenerHeaders(), null, true);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response.Result);

        }

    }
}
