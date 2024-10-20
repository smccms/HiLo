using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    public const string wssUrl = "http://localhost:5211/hl";
    static void Main(string[] args)
    {
        var connectionSignalR = new HubConnectionBuilder()
           .WithUrl(wssUrl)
           .Build();
        connectionSignalR.On<string>("ReceiveMessage", text => Console.WriteLine(text));
        connectionSignalR.StartAsync().Wait();
        do
        {
            var input = Console.ReadLine();
            if ("exit".Equals(input))
            {
                connectionSignalR.StopAsync().Wait();
                break;
            }
            if (int.TryParse(input, out int guess))
            {
                connectionSignalR.SendAsync("SubmitGuess", guess).Wait();
            }
            else{
                Console.WriteLine("Please insert a number ou 'exit' to quit the game.");
            }
        } while (true);
    }
}