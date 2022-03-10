using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Communicator.ApiServer.Hubs
{
    public class MessangerHub : Hub
    {
        public async Task AddToGroupAsync(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageAsync(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("Messages", user, message);
        }
    }
}