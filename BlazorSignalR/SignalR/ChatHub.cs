using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName, string mail)
        {
            await Clients.All.SendAsync("Receive", message, userName, mail);
        }
    }
}