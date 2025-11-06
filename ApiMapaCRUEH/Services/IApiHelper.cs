using ApiMapaCRUEH.Clases;

namespace ApiMapaCRUEH.Services
{
    public interface IApiHelper
    {
        Task<Response> Get<T>(string urlBase, string servicePrefix, string controller,string token, Dictionary<string, string> headers, bool Json = true);

        Task<Response> Post<T, K>(string urlBase, string servicePrefix, string controller, string token, Dictionary<string, string> headers, T requestModel, bool responseList, bool Json = true);

        Task<Response> Post<T>(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, Dictionary<string, string> form);
    }
}
