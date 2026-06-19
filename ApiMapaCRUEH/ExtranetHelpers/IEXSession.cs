using ApiMapaCRUEH.Clases;

namespace ApiMapaCRUEH.ExtranetHelpers
{
		public interface IEXSession
		{
				public Task<Response> ObtenerSessionExtranet();

				public Dictionary<string, string> ObtenerHeaders();

				public string Usuario { get; set; }

				public string Password { get; set; }
		}
}
