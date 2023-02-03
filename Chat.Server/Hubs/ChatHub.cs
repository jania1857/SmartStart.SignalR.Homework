using Microsoft.AspNetCore.SignalR;

namespace Chat.Server.Hubs
{
	public class ChatHub : Hub
	{
		public async Task SendMessage(string username, string message)
		{ 
			await Clients.All.SendAsync("ShowMessage", username, message);
		}
	}
}
