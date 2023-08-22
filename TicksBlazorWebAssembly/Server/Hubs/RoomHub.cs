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

        public async Task RaiseHand(string? browserId)
        {
            await Clients.Group("Tutors").SendAsync("LearnerHasRaisedHand", browserId);
        }

        public async Task Leave()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Learners");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Tutors");
        }

    }
}
