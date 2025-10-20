using ApiMapaCRUEH.Clases;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiMapaCRUEH.Services
{
    public class ApiHelper
    {
        public async Task<Response> Get<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = response.IsSuccessStatusCode,
                        Message = response.ReasonPhrase,
                        Code = response.StatusCode.ToString(),
                        ResponseMessage = response

                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var json = (result.Substring(1, result.Length - 2).Remove(0, result.IndexOf(":")));
                var listado = JsonConvert.DeserializeObject<List<T>>(json);
                return new Response
                {
                    IsSuccess = response.IsSuccessStatusCode,
                    Message = response.ReasonPhrase,
                    Result = listado,
                    ResponseMessage = response
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> Post<T>(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = response.IsSuccessStatusCode,
                        Message = response.ReasonPhrase,
                        Code = response.StatusCode.ToString(),
                        ResponseMessage = response
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = response.ReasonPhrase,
                    Result = newRecord,
                    ResponseMessage = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }


        public async Task<Response> Post<T>(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, Dictionary<string, string> form)
        {
            try
            {
                var request = new FormUrlEncodedContent(form);
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.PostAsync(url, request);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = response.IsSuccessStatusCode,
                        Message = response.ReasonPhrase,
                        Code = response.StatusCode.ToString(),
                        ResponseMessage = response
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var newRecord = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = response.ReasonPhrase,
                    Result = newRecord,
                    ResponseMessage = response
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

    }
}
