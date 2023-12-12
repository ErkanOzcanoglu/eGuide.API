using System.Threading.Tasks;

namespace eGuide.Common.SignalR {
    public interface IHubClient {
        Task BroadcastMessage();
    }
}
