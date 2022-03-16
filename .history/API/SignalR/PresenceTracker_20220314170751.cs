using System.Collections.Generic;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private static readyonly  DI<string, List<string>> OnlineUsers = new Dictionary<string, List<string>>();


    }
}