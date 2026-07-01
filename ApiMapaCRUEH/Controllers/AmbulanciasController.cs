using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMapaCRUEH.Controllers
{
		[Route("backendcrueh/[controller]")]
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


				[HttpPost]
				[Route("RegistrarTomasMedicion")]
				public async Task<IActionResult> RegistrarTomasMedicion(ParametrosTomasMedicionAph datosTomasMedicions)
				{
						var response = await _apiHelper.Post<ParametrosTomasMedicionAph, Ambulancia>(_options.ApiEextranetBaseUrl, _options.RegistrarTomasMedicion, "", "", _session.ObtenerHeaders(), datosTomasMedicions, false, false);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}

				[HttpPost]
				[Route("IniciarTurnoAmbulancia")]
				public async Task<IActionResult> IniciarTurnoAmbulancia(ParametrosIniciarTurnoAmbulancia datosIniciarTurno)
				{
						var response = await _apiHelper.Post<ParametrosIniciarTurnoAmbulancia, object>(_options.ApiEextranetBaseUrl, _options.IniciarTurnoAmbulancia, "", "", _session.ObtenerHeaders(), datosIniciarTurno, false, false);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}

				[HttpPost]
				[Route("FinalizarTurnoAmbulancia")]
				public async Task<IActionResult> FinalizarTurnoAmbulancia(ParametrosFinalizarTurnoAmbulancia datosFinalizarTurno)
				{
						var response = await _apiHelper.Post<ParametrosFinalizarTurnoAmbulancia, object>(_options.ApiEextranetBaseUrl, _options.FinalizarTurnoAmbulancia, "", "", _session.ObtenerHeaders(), datosFinalizarTurno, false, false);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}

				[HttpPost]
				[Route("CambiarDisponibilidadAmbulancia")]
				public async Task<IActionResult> CambiarDisponibilidadAmbulancia(ParametrosCambiarDisponibilidadAmbulancia parametrosCambiarDisponibilidadAmbulancia)
				{
						var response = await _apiHelper.Post<ParametrosCambiarDisponibilidadAmbulancia, object>(_options.ApiEextranetBaseUrl, _options.CambiarDisponibilidadAmbulancia, "", "", _session.ObtenerHeaders(), parametrosCambiarDisponibilidadAmbulancia, false, false);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}



		}
}
