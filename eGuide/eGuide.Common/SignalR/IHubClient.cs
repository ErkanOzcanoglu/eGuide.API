using System.Threading.Tasks;

namespace eGuide.Common.SignalR {
    public interface IHubClient {
        
        /// <summary>
        /// Broadcasts the message.
        /// </summary>
        /// <returns></returns>
        Task BroadcastMessage();
    }
}
