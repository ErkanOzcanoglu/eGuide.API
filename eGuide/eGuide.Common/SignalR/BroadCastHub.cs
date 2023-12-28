using Microsoft.AspNetCore.SignalR;

namespace eGuide.Common.SignalR {
    
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.SignalR.Hub&lt;eGuide.Common.SignalR.IHubClient&gt;" />
    public class BroadCastHub : Hub<IHubClient> {
    }
}
