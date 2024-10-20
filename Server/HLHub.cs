using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class HLHub : Hub
{
    private readonly IHiLoGame hiLoGame;

    public HLHub(IHiLoGame hiLoGame)
    {
        this.hiLoGame = hiLoGame;
    }
    
    public override async Task OnConnectedAsync()
    {
        var msg = hiLoGame.AddPlayer(Context.ConnectionId);
        await Clients.Caller.SendAsync("ReceiveMessage", msg);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        hiLoGame.RemovePlayer(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SubmitGuess(int param)
    {
        hiLoGame.SubmitPlayerGuess(Context.ConnectionId, param);
        if (hiLoGame.IsWaitingForPlayers())
        {
            await Clients.Caller.SendAsync("ReceiveMessage", hiLoGame.GetWaitingMessage());
        }
        else
        {       
            if(hiLoGame.HasGuessed()){
                hiLoGame.GenerateNewNumber();
                await SendAll(hiLoGame.GetHasGuessedMessage());
            }else{
                await SendAll(hiLoGame.GetPlayersScores());
            }
        }
    }

    public async Task SendAll(string text)
    {
        await Clients.All.SendAsync("ReceiveMessage", text);
    }
}