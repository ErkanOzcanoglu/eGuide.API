using eGuide.Business.Interface;
using eGuide.Data.Dto.OutComing.Station;
using eGuide.Data.Entites.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class StationChargingUnitBusiness : Business<StationsChargingUnits>, IStationChargingUnitBusiness {
        private readonly IStationChargingUnitRepository _repository;

        public StationChargingUnitBusiness(IStationChargingUnitRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
        }

        public async Task<StationsChargingUnits> GetChargingUnitByStationId(Guid id) {
            var sockets = await _repository.GetChargingUnitByStationId(id);
            if (sockets == null) {
                return null;
            }
            return sockets;
        }
    }
}
