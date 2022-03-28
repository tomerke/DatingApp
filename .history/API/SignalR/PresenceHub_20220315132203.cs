using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace API.SignalR
{
  [Authorize]
    public class PresenceHub: Hub
    {
        public PresenceHub(PresenceTracker )
        {
        }

        public override async Task OnConnectedAsync()
      {
          await
          await Clients.Others.SendAsync("UserIsOnline", Context.User.GetUsername());

      }


      public override async Task OnDisconnectedAsync(Exception exception)
      {
          await Clients.Others.SendAsync("UserIsOffline", Context.User.GetUsername());

          await base.OnDisconnectedAsync(exception);
      }
    }
}