using ApiMapaCRUEH.Clases;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using ApiMapaCRUEH.Services;

namespace ApiMapaCRUEH.ExtranetHelpers
{
    public class EXSession : IEXSession
    {
        private readonly ExtranetServiceOptions _options;
        private readonly IApiHelper _apiHelper;
        private readonly Dictionary<string, string> _headers;

        public EXSession(IConfiguration configuration, IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
            _options = configuration.GetSection("ExtranetServices").Get<ExtranetServiceOptions>();
            _headers = new Dictionary<string, string>();
            ObtenerSessionExtranet().Wait();
        }

        public async Task<Response> ObtenerSessionExtranet()
        {
            var responseAutenticar = await _apiHelper.Post<AutenticarMovilDto, UsuarioAutenticado>(_options.ApiEextranetBaseUrl, _options.AutenticarMovil, "", "", null,
                         new AutenticarMovilDto
                         {
                             NombreUsuario = _options.UsuarioExtranet,
                             Clave = _options.PasswordExtranet,
                             Recordar = false
                         },
                         false
           );

            if (!responseAutenticar.IsSuccess)
            {
                return responseAutenticar;
            }

            string dotnetnuke = responseAutenticar.Cookies[".DOTNETNUKE"].Value.Trim();


            if (dotnetnuke != string.Empty)
            {
                var responsePagina = await _apiHelper.Get<Response>(_options.ApiEextranetBaseUrl, "", "", dotnetnuke, null, false);

                if (!responsePagina.IsSuccess)
                {
                    return responsePagina;
                }

                var paginaHtml = responsePagina.Result.ToString();

                var requestVerificationToken = paginaHtml?.Split('>').Select(c => c.Trim()).First(p => p.Contains("__RequestVerificationToken"));

                if (requestVerificationToken != null && requestVerificationToken != string.Empty)
                {
                    _headers.Clear();
                    requestVerificationToken = requestVerificationToken?.Substring(requestVerificationToken.LastIndexOf("=") + 2).Replace("\"", string.Empty).Replace("/", string.Empty);
                    _headers.Add("__RequestVerificationToken", requestVerificationToken);
                    _headers.Add(".DOTNETNUKE", dotnetnuke);
                }


            }

            return responseAutenticar;
        }

        Dictionary<string, string> IEXSession.ObtenerHeaders()
        {
            return _headers;
        }


    }
}
