using Microsoft.AspNetCore.SignalR;

namespace TicksBlazorWebAssembly.Server.Hubs
{
    public class RoomHub : Hub
    {
        public async Task JoinAsTutor()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Tutors");
        }

        public async Task JoinAsLearner()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Learners");
        }

        public async Task RaiseHand()
        {
            await Clients.Group("Tutors").SendAsync("LearnerHasRaisedHand", Context.ConnectionId);
        }
    }
}
