using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class StationBusiness : Business<StationProfile>, IStationBusiness {

        /// <summary>
        /// The station repository
        /// </summary>
        private readonly IStationRepository _stationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationBusiness"/> class.
        /// </summary>
        /// <param name="stationRepository">The station repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public StationBusiness(IStationRepository stationRepository, IUnitOfWork unitOfWork) : base(stationRepository, unitOfWork) {
            _stationRepository = stationRepository;
        }

        /// <summary>
        /// Gets all s.
        /// </summary>
        /// <returns></returns>
        public Task<List<StationProfile>> GetAllS() {
            return _stationRepository.GetStationProf();
        }

        /// <summary>
        /// Gets the station profile.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Task<StationProfile> GetStationProfile(Guid Id)
        {
            return _stationRepository.GetStationProfile(Id);
        }
    }
}
