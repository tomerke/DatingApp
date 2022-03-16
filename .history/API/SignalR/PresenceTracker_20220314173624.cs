using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.SignalR
{
    public class PresenceTracker
    {
        private readonly Dictionary<string, List<string>> OnLineUsers = new Dictionary<string, List<string>>();

        public Task UserConnected(string username, string connectionId)
        {
            lock (OnLineUsers)
            {
                if (OnLineUsers.ContainsKey(username))
                {
                    OnLineUsers[username].Add(connectionId);
                }
                else
                {
                    OnLineUsers.Add(username, new List<string> { connectionId });
                }
                return Task.CompletedTask;
            }
        }


        public Task UserDisconnected(string username, string connectionId)
        {
            lock (OnLineUsers)
            {
                if (!OnLineUsers.ContainsKey(username)) return Task.CompletedTask;

                

            }
        }


    }
}