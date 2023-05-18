using Microsoft.AspNetCore.SignalR;

namespace PizzeriaMVC.Code
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToAll(string user, string message)
        {
            Console.WriteLine($"Message received from {user}> {message}");
            await Clients.All.SendAsync("ReceiveMessageFromAll", user, message);
        }
    }
}
