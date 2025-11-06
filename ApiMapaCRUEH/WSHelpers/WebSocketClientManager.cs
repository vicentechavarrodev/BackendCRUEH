using ApiMapaCRUEH.Services;
using Newtonsoft.Json;
using System;
using System.Net.WebSockets;
using System.Text;

namespace ApiMapaCRUEH.WSHelpers
{
    public class WebSocketClientManager
    {
        private readonly ClientWebSocket _webSocket;
        private readonly ApiHelper _apiHelper;
        private readonly WebSocketConnectionManager _connectionManager;


        public WebSocketClientManager(ApiHelper apiHelper, WebSocketConnectionManager connectionManager)
        {
            _webSocket = new ClientWebSocket();
            _apiHelper = apiHelper;
            _connectionManager = connectionManager;
            _ = ConnectToWebSocket();
            _connectionManager = connectionManager;
        }
        async Task ConnectToWebSocket()
        {
            using (_webSocket)
            {

                _webSocket.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);

                CancellationTokenSource cts = new CancellationTokenSource();

                try
                {
                    var wst = Environment.GetEnvironmentVariable("SOCKET_TRACCAR");

                    if (_webSocket.State != WebSocketState.Open)
                    {
                        var response = await _apiHelper.Post<object>(Environment.GetEnvironmentVariable("SESSION_TRACCAR"), "", "", "", "",
                            new Dictionary<string, string>
                            {
                            { "email", Environment.GetEnvironmentVariable("USUARIO_TRACCAR") },
                            { "password", Environment.GetEnvironmentVariable("PASSWORD_TRACCAR") }
                            });

                        var sessionId = response.ResponseMessage.Headers.GetValues("Set-Cookie").FirstOrDefault();

                        _webSocket.Options.SetRequestHeader("Cookie", sessionId);

                        await _webSocket.ConnectAsync(new Uri(wst), cts.Token);

                        byte[] buffer = new byte[1024];


                        while (_webSocket.State == WebSocketState.Open)
                        {
                            WebSocketReceiveResult result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

                            if (result.MessageType == WebSocketMessageType.Text)
                            {
                                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);


                                foreach (var socket in _connectionManager.GetAllSockets())
                                {
                                    if (socket.State == WebSocketState.Open)
                                    {
                                        var responseMessage = Encoding.UTF8.GetBytes(message);
                                        await socket.SendAsync(new ArraySegment<byte>(responseMessage, 0, responseMessage.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                                    }
                                }


                            }
                            else if (result.MessageType == WebSocketMessageType.Close)
                            {
                                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                                break;
                            }
                        }

                    }


                }
                catch (WebSocketException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (_webSocket.State != WebSocketState.Closed)
                    {
                        await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", cts.Token);
                    }
                }
            }
        }

    }
}
