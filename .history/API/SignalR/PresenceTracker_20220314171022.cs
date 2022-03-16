using System.Collections.Generic;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private static readyonly  Diction<string, List<string>> OnlineUsers = new Dictionary<string, List<string>>();


    }
}