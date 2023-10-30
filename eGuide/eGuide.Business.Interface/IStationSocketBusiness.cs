using eGuide.Data.Entites.Station;
using eGuide.Data.Dto.OutComing.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IStationSocketBusiness: IBusiness<StationSockets> {
        //get sockets by station id
        Task<StationSockets> GetSocketsByStationId(Guid id);
    }
}
