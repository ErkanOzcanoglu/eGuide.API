using eGuide.Data.Entities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Hubs
{
    public interface IHubClient
    {
        Task BroadcastMessage(Messages message);
    }
}
