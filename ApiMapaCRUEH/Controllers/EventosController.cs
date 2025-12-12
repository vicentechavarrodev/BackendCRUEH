using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMapaCRUEH.Controllers
{
		[Route("backendcrueh/[controller]")]
		[ApiController]
		public class EventosController : ControllerBase
		{

				private readonly IApiHelper _apiHelper;
				private readonly ExtranetServiceOptions _options;
				private readonly IEXSession _session;
				private readonly INotificationService _notificationService;
				public EventosController(IEXSession session, IApiHelper apiHelper, IConfiguration configuration, INotificationService notificationService)
				{
						_apiHelper = apiHelper;
						_options = configuration.GetSection("ExtranetServices").Get<ExtranetServiceOptions>();
						_session = session;
						_notificationService = notificationService;

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

				[HttpPost]
				[Route("DatosEventosAPHAmbulancias")]
				public async Task<IActionResult> DatosEventosAPHAmbulancias(ParamsNuevoRegistroAPHAmbulancia paramsObtenerListaEventosactivos)
				{
						var response = await _apiHelper.Post<ParamsNuevoRegistroAPHAmbulancia, object>(_options.ApiEextranetBaseUrl, _options.DatosEventosAPHAmbulancias, "", "", _session.ObtenerHeaders(), paramsObtenerListaEventosactivos, false);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}


				[HttpPost]
				[Route("ObtenerListaEventosActivos")]
				public async Task<IActionResult> ObtenerListaEventosActivos()
				{
						var response = await _apiHelper.Post<object, DatosEventosAPHAmbulancias>(_options.ApiEextranetBaseUrl, _options.ObtenerListaEventosActivos, "", "", _session.ObtenerHeaders(), null, true);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}


				[HttpPost]
				[Route("AsignarAmbulancia")]
				public async Task<IActionResult> AsignarAmbulancia(ParamsAsignarAmbulanciaDto paramsAsignarAmbulanciaDto)
				{
						var response = await _apiHelper.Post<ParamsAsignarAmbulanciaDto, object>(_options.ApiEextranetBaseUrl, _options.AsignarAmbulancia, "", "", _session.ObtenerHeaders(), paramsAsignarAmbulanciaDto, false);

						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						var success = await _notificationService
							.RequestNotificationAsync(new NotificationRequestDto
							{
									Action = "action_a",
									Text = "Se le ha asignado una emergencia,click para ver.",
									Silent = true,
									Tags = ["ambulancia1"],
									IdEvento = paramsAsignarAmbulanciaDto.ID.ToString()
							}, HttpContext.RequestAborted);

						return Ok(response.Result);

				}

				[HttpPost]
				[Route("ObtenerListaIPSMonitoreo")]
				public async Task<IActionResult> ObtenerListaIPSMonitoreo()
				{
						var response = await _apiHelper.Post<object, IPS>(_options.ApiEextranetBaseUrl, _options.ObtenerListaIPSMonitoreo, "", "", _session.ObtenerHeaders(), null, true);


						if (!response.IsSuccess)
						{
								return BadRequest(response);
						}
						return Ok(response.Result);

				}

				[HttpPost]
				[Route("ObtenerEvento")]
				public async Task<IActionResult> ObtenerEvento(ConsultarEventoDto consultarEvento)
				{

						var response = await ObtenerListaEventosActivos();

						if (response is OkObjectResult okResult)
						{
								var value = okResult.Value;
								if (value is List<DatosEventosAPHAmbulancias> datosEventos)
								{
										var evento = datosEventos.FirstOrDefault(e => e.ID == int.Parse(consultarEvento.IdEvento));
										if (evento != null)
										{
												return Ok(evento);
										}
										else
										{
												return NotFound(new { Message = "Evento no encontrado." });
										}
								}

						}
						return Ok(null);

				}



		}
}
