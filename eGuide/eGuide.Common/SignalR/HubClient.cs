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

        /// <summary>
        /// The hub context
        /// </summary>
        private readonly IHubContext<BroadCastHub> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="HubClient"/> class.
        /// </summary>
        /// <param name="hubContext">The hub context.</param>
        public HubClient(IHubContext<BroadCastHub> hubContext) {
            _hubContext = hubContext;
        }

        /// <summary>
        /// Broadcasts the message.
        /// </summary>
        /// <param name="mail">The mail.</param>
        public async Task BroadcastMessage(Mail mail) {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", mail);
        }
    }
}
