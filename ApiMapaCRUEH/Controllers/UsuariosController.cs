using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiMapaCRUEH.Controllers
{
		[Route("backendcrueh/[controller]")]
		[ApiController]
		public class UsuariosController : ControllerBase
		{
				private readonly IApiHelper _apiHelper;
				private readonly ExtranetServiceOptions _options;
				private readonly IEXSession _session;

				public UsuariosController(IEXSession session, IApiHelper apiHelper, IConfiguration configuration)
				{
						_apiHelper = apiHelper;
						_options = configuration.GetSection("ExtranetServices").Get<ExtranetServiceOptions>();
						_session = session;


				}

				[HttpPost]
				[Route("IniciarSesion")]
				public async Task<IActionResult> IniciarSesion(AutenticarMovilDto autenticarMovilDto)
				{
						var usuarioAutenticado = await _apiHelper.Post<AutenticarMovilDto, UsuarioAutenticado>(_options.ApiEextranetBaseUrl, _options.AutenticarMovil, "", "", null,
									autenticarMovilDto,
										false
						);

						if (!usuarioAutenticado.IsSuccess)
						{
								return BadRequest(usuarioAutenticado);
						}

						if (((UsuarioAutenticado)usuarioAutenticado.Result).IDUsuario > 0)
						{
								await _session.ObtenerSessionExtranet();
								var responseSessionAmbulancia = await _apiHelper.Post<ParamsConsultarSesionDto, DatosSesionAmbulancia>(_options.ApiEextranetBaseUrl, _options.IniciarSesionAmbulancia, "", "", _session.ObtenerHeaders(),
						new ParamsConsultarSesionDto
						{
								IDUsuario = ((UsuarioAutenticado)usuarioAutenticado.Result).IDUsuario,
								NombreUsuario = ((UsuarioAutenticado)usuarioAutenticado.Result).NombreUsuario
						}, false);
								if (!responseSessionAmbulancia.IsSuccess)
								{
										return BadRequest(responseSessionAmbulancia);
								}
								return Ok(responseSessionAmbulancia.Result);

						}
						return Ok(usuarioAutenticado.Result);

				}

				[HttpPost]
				[Route("CerrarSesion")]
				public async Task<IActionResult> CerrarSesion(AutenticarMovilDto autenticarMovilDto)
				{
						var usuarioAutenticado = await _apiHelper.Post<AutenticarMovilDto, UsuarioAutenticado>(_options.ApiEextranetBaseUrl, _options.AutenticarMovil, "", "", null,
									autenticarMovilDto,
										false
						);

						if (!usuarioAutenticado.IsSuccess)
						{
								return BadRequest(usuarioAutenticado);
						}

						if (((UsuarioAutenticado)usuarioAutenticado.Result).IDUsuario > 0)
						{
								await _session.ObtenerSessionExtranet();
								var responseSessionAmbulancia = await _apiHelper.Post<ParamsConsultarSesionDto, DatosSesionAmbulancia>(_options.ApiEextranetBaseUrl, _options.CerrarSesionAmbulancia, "", "", _session.ObtenerHeaders(),
						new ParamsConsultarSesionDto
						{
								IDUsuario = ((UsuarioAutenticado)usuarioAutenticado.Result).IDUsuario,
								NombreUsuario = ((UsuarioAutenticado)usuarioAutenticado.Result).NombreUsuario
						}, false);
								if (!responseSessionAmbulancia.IsSuccess)
								{
										return BadRequest(responseSessionAmbulancia);
								}
								return Ok(responseSessionAmbulancia.Result);

						}
						return Ok(usuarioAutenticado.Result);

				}
		}
}
