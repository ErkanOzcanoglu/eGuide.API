using eGuide.Data.Entities.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Hubs
{
    public class HubClient : IHubClient
    {
        private readonly IHubContext<BroadCastHub, IHubClient> _hubContext;

        public HubClient(IHubContext<BroadCastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task BroadcastMessage(Messages message)
        {
            await _hubContext.Clients.All.BroadcastMessage(message);
        }
    }
}
