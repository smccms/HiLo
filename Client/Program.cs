using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    public const string wssUrl = "http://localhost:5211/hl";
    static async Task Main(string[] args)
    {
        var connectionSignalR = new HubConnectionBuilder()
           .WithUrl(wssUrl)
           .Build();
        connectionSignalR.On<string>("ReceiveMessage", text => Console.WriteLine(text));
        await connectionSignalR.StartAsync();
        do
        {
            var input = Console.ReadLine();
            if ("exit".Equals(input))
            {
                await connectionSignalR.StopAsync();
                break;
            }
            if (int.TryParse(input, out int guess))
            {
                await connectionSignalR.SendAsync("SubmitGuess", guess);
            }
            else{
                Console.WriteLine("Please insert a number ou 'exit' to quit the game.");
            }
        } while (true);
    }
}