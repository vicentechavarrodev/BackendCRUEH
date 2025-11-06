using ApiMapaCRUEH.Clases;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ApiMapaCRUEH.Services
{
    public class ApiHelper : IApiHelper
    {
        private readonly CookieContainer _cookieContainer;
        private readonly HttpClientHandler _handler;
        private HttpClient _httpClient;


        public ApiHelper()
        {
            _cookieContainer = new CookieContainer();
            _handler = new HttpClientHandler { CookieContainer = _cookieContainer, UseCookies = true, AllowAutoRedirect = true };

        }

        public async Task<Response> Get<T>(string urlBase, string servicePrefix, string controller, string token, Dictionary<string, string> headers, bool Json = true)
        {

            try
            {
                _httpClient = new HttpClient(_handler);
                _httpClient.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                if (token != string.Empty) _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                var response = await _httpClient.GetAsync(url);

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

                if (Json)
                {
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
                else
                {
                    return new Response
                    {
                        IsSuccess = response.IsSuccessStatusCode,
                        Message = response.ReasonPhrase,
                        Result = result,
                        ResponseMessage = response
                    };
                }

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

        public async Task<Response> Post<T, K>(string urlBase, string servicePrefix, string controller, string token, Dictionary<string, string> headers, T requestModel, bool responseList, bool Json = true)
        {
            try
            {
                _httpClient = new HttpClient(_handler);
                _httpClient.BaseAddress = new Uri(urlBase);
                var request = JsonConvert.SerializeObject(requestModel);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var url = string.Format("{0}{1}", servicePrefix, controller);
                if (token != string.Empty) _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                var response = await _httpClient.PostAsync(url, content);

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

                object objectResult;

                if (responseList)
                {
                    objectResult = JsonConvert.DeserializeObject<List<K>>(result);
                }
                else
                {
                    objectResult = JsonConvert.DeserializeObject<K>(result);
                }

                var cookies = _cookieContainer.GetCookies(_httpClient.BaseAddress);


                return new Response
                {
                    IsSuccess = true,
                    Message = response.ReasonPhrase,
                    Result = objectResult,
                    ResponseMessage = response,
                    Cookies = cookies
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
                _httpClient = new HttpClient(_handler);
                _httpClient.BaseAddress = new Uri(urlBase);
                var request = new FormUrlEncodedContent(form);
                _httpClient.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await _httpClient.PostAsync(url, request);

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
