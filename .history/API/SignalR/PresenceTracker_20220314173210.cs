using System.Collections.Generic;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private readonly Dictionary<string, List<string>> OnLineUsers = new Dictionary<string, List<string>>();

        public Task UserConnected(string username, string connectionId)


    }
}