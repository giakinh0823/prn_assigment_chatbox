using Microsoft.AspNetCore.SignalR;

namespace prn_job_manager.Hubs;

public class NotifyHub : Hub
{
    public void SendNotifyToGroup(string groupId, string message)
    {
        Clients.Group(groupId).SendAsync("Notify", message);
    }

    public void JoinGroup(string groupId)
    {
        Groups.AddToGroupAsync(Context.ConnectionId, groupId);
    }

    public void RemoveFromGroup(string groupId)
    {
        Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
    }
}