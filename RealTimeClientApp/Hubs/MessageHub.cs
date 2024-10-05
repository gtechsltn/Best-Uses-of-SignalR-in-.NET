using Microsoft.AspNetCore.SignalR;

namespace RealTimeClientApp.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // Broadcasts the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
