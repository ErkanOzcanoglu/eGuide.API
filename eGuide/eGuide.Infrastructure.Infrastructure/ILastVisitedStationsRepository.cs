using eGuide.Data.Dto.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {
    public interface ILastVisitedStationsRepository {
        Task<LastVisitedStations> CreateUsersLog(LastVisitedStations lvs);
        Task<IEnumerable<LastVisitedStations>> GetLastVisitedStationsByUserId(Guid id);
        Task<LastVisitedStations> RemoveLastVisitedStation(Guid id);
    }
}
