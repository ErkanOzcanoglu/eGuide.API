using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entities.Message;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.SignalR {
    public class HubClient : Hub {
        private readonly IHubContext<BroadCastHub> _hubContext;

        public HubClient(IHubContext<BroadCastHub> hubContext) {
            _hubContext = hubContext;
        }

        public async Task BroadcastMessage(Mail mail) {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", mail);
        }
    }
}
