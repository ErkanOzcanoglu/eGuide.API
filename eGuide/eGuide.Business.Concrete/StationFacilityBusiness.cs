using eGuide.Business.Interface;
using eGuide.Data.Entites.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class StationFacilityBusiness : Business<StationFacility>, IStationFacilityBusiness {

        /// <summary>
        /// The station facility repository
        /// </summary>
        private readonly IStationFacilityRepository _stationFacilityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationFacilityBusiness"/> class.
        /// </summary>
        /// <param name="stationFacilityRepository">The station facility repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public StationFacilityBusiness(IStationFacilityRepository stationFacilityRepository, IUnitOfWork unitOfWork) : base(stationFacilityRepository, unitOfWork) {
            _stationFacilityRepository = stationFacilityRepository;
        }

        /// <summary>
        /// Gets the allfac.
        /// </summary>
        /// <returns></returns>
        public async Task<List<StationFacility>> GetAllfac() {
            return await _stationFacilityRepository.GetAllFacility();
        }

        /// <summary>
        /// Gets the fac by station identifier.
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <returns></returns>
        public async Task<List<StationFacility>> GetFacByStationId(Guid stationId) {
            return await _stationFacilityRepository.GetFacilityByStationId(stationId);
        }
    }
}
