using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface
{
    public interface IUserStationBusiness:IBusiness<UserStation>
    {
        /// <summary>
        /// Gets the user stations profiles asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<List<StationProfile>> GetUserStationsProfilesAsync(Guid userId);
    }
}
