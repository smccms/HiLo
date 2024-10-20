using Microsoft.AspNetCore.SignalR;

public class HLHub : Hub
{
    HiLoGame hiLoGame = new HiLoGame();

    public string Send(string message)
    {
        return message;
    }

    public override Task OnConnectedAsync()
    {
        var msg = hiLoGame.AddPlayer(Context.ConnectionId);
        Clients.Caller.SendAsync("ReceiveMessage", msg);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        hiLoGame.RemovePlayer(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }

    public Task SubmitGuess(int param)
    {
        hiLoGame.SubmitPlayerGuess(Context.ConnectionId, param);
        if (hiLoGame.IsWaitingForPlayers())
        {
            Clients.Caller.SendAsync("ReceiveMessage", hiLoGame.GetWaitingMessage());
        }
        else
        {       
            if(hiLoGame.HasGuessed()){
                hiLoGame.GenerateNewNumber();
                SendAll(hiLoGame.GetHasGuessedMessage());
            }else{
                SendAll(hiLoGame.GetPlayersScores());
            }
        }
        return Task.CompletedTask;
    }

    public Task SendAll(string text)
    {
        if (Clients != null)
            return Clients.All.SendAsync("ReceiveMessage", text);
        return Task.CompletedTask;
    }
}