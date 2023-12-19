using eGuide.Data.Entities.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Hubs
{
    public class BroadCastHub:Hub<IHubClient>
    {
        private readonly IHubContext<BroadCastHub, IHubClient> _hubContext;

        public BroadCastHub(IHubContext<BroadCastHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task BroadcastMessage(Messages message)
        {
            var receiverIdString = message.ReceiverId.ToString();
            await _hubContext.Clients.User(receiverIdString).BroadcastMessage(message);
        }
    }
}
