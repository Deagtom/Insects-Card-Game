using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

public class GameHub : Hub
{
    private static ConcurrentDictionary<string, string> Connections = new();

    public override Task OnConnectedAsync()
    {
        // ��������� ���������� � ������
        Connections[Context.ConnectionId] = "UnknownPlayer";
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        // ������� ���������� �� ������
        Connections.TryRemove(Context.ConnectionId, out _);
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}