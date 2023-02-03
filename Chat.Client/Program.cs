using Microsoft.AspNetCore.SignalR.Client;

namespace Chat.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var connection = new HubConnectionBuilder()
				.WithUrl("http://localhost:5000/hubs/chat")
				.Build();

			await connection.StartAsync();

			
			Console.WriteLine("Podaj swoją nazwę użytkownika: ");
			string cUsername = Console.ReadLine();
			Console.WriteLine($"Witaj {cUsername}! Możesz rozpocząć swoją konwersację z innymi użytkownikami czatu!");


			

			connection.On<string, string>("ShowMessage", (username, message) =>
			{
				Console.WriteLine($"{username}: {message}");
			});

			while (true)
			{
				string CMessage = Console.ReadLine();
				await connection.SendAsync("SendMessage", cUsername, CMessage);
			}
		}
	}
}