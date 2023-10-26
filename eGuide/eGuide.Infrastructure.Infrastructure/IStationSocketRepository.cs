using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Station;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entites.Station.StationSockets&gt;" />
    public interface IStationSocketRepository : IGenericRepository<StationSockets> {
        //get sockets by station id
        Task<StationSockets> GetSocketsByStationId(Guid id);
    }
}
