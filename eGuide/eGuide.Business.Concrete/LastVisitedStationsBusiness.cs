using eGuide.Business.Interface;
using eGuide.Data.Dto.Logger;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class LastVisitedStationsBusiness : ILastVisitedStationsBusiness {

        /// <summary>
        /// The last visited stations repository
        /// </summary>
        private readonly ILastVisitedStationsRepository _lastVisitedStationsRepository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastVisitedStationsBusiness"/> class.
        /// </summary>
        /// <param name="lastVisitedStationsRepository">The last visited stations repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public LastVisitedStationsBusiness(ILastVisitedStationsRepository lastVisitedStationsRepository, IUnitOfWork unitOfWork) {
            _lastVisitedStationsRepository = lastVisitedStationsRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the users log.
        /// </summary>
        /// <param name="lvs">The LVS.</param>
        public async void CreateUsersLog(LastVisitedStations lvs) {
            await _lastVisitedStationsRepository.CreateUsersLog(lvs);
        }

        /// <summary>
        /// Gets the last visited stations by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<LastVisitedStations>> GetLastVisitedStationsByUserId(Guid id) {
            try {
                var result = await _lastVisitedStationsRepository.GetLastVisitedStationsByUserId(id);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Removes the last visited station.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<LastVisitedStations> RemoveLastVisitedStation(Guid id) {
            try {
                var result = await _lastVisitedStationsRepository.RemoveLastVisitedStation(id);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
