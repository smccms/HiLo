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
        while (true);
    }
}