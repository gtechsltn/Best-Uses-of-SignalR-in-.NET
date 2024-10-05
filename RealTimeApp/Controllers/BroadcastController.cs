using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeApp.Hubs;

namespace RealTimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public BroadcastController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromQuery] string user, [FromQuery] string message)
        {
            // Trigger SignalR message broadcast
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
            return Ok(new { Message = "Message sent to all clients" });
        }
    }
}
