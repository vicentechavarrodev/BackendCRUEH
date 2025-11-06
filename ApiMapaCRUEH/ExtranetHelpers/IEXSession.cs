using ApiMapaCRUEH.Clases;

namespace ApiMapaCRUEH.ExtranetHelpers
{
    public interface IEXSession
    {
        public Task<Response> ObtenerSessionExtranet();

        public Dictionary<string, string> ObtenerHeaders();
    }
}
