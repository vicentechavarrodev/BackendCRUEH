using System.Linq;
using System.Net.WebSockets;

namespace ApiMapaCRUEH.WSHelpers
{
    public class WebSocketConnectionManager
    {

        private readonly Dictionary<string, WebSocket> _sockets = new Dictionary<string, WebSocket>();

        public WebSocket GetSocketById(string id)
        {
            return _sockets.FirstOrDefault(p => p.Key == id).Value;
        }

        public string GetSocketId(WebSocket ws)
        {
            return _sockets.FirstOrDefault(p => p.Value.Equals(ws)).Key;
        }

        public void AddSocket(WebSocket socket)
        {
            _sockets.Add(Guid.NewGuid().ToString(), socket);
        }

        public async Task RemoveSocket(string id)
        {
            if (_sockets.TryGetValue(id, out WebSocket socket))
            {
                _sockets.Remove(id);
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Cierre de conexión", CancellationToken.None);
            }
        }

        public IEnumerable<WebSocket> GetAllSockets()
        {
            return _sockets.Values;
        }
    }
}
