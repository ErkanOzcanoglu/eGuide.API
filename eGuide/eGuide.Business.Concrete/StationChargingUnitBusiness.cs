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

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IStationChargingUnitRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationChargingUnitBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public StationChargingUnitBusiness(IStationChargingUnitRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
        }

        /// <summary>
        /// Gets the charging unit by station identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<StationsChargingUnits> GetChargingUnitByStationId(Guid id) {
            var sockets = await _repository.GetChargingUnitByStationId(id);
            if (sockets == null) {
                return null;
            }
            return sockets;
        }
    }
}
