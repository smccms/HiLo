using System;
using Microsoft.AspNetCore.SignalR;

public class HLHub : Hub
{
    public override Task OnConnectedAsync()
    {
        SendAll("Test");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        return base.OnDisconnectedAsync(exception);
    }

    public Task SendAll(string text)
    {
        if (Clients != null)
            return Clients.All.SendAsync("ReceiveMessage", text);
        return Task.CompletedTask;
    }
}