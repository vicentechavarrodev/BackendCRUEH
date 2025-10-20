using System.Net.WebSockets;
using System.Text;

namespace ApiMapaCRUEH.WSHelpers
{
    public class GPSWebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketConnectionManager _connectionManager;
     

        public GPSWebSocketMiddleware(RequestDelegate next, WebSocketConnectionManager connectionManager, WebSocketClientManager webSocketClientManager)
        {
            _next = next;
            _connectionManager = connectionManager;
         
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest && context.Request.Path == "/gpssocket")
            {
               
                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                _connectionManager.AddSocket(webSocket);
                await ReceiveMessagesAsync(webSocket);
            }
            else
            {
                await _next(context);
            }
        }

        private async Task ReceiveMessagesAsync(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
               
                foreach (var socket in _connectionManager.GetAllSockets())
                {
                    if (socket.State == WebSocketState.Open)
                    {
                        var responseMessage = Encoding.UTF8.GetBytes(message);
                        await socket.SendAsync(new ArraySegment<byte>(responseMessage, 0, responseMessage.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                    }
                }

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            WebSocket s = _connectionManager.GetSocketById(webSocket.GetHashCode().ToString());
            string id  = _connectionManager.GetSocketId(s);

            await _connectionManager.RemoveSocket(id);
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
