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

        private readonly ILastVisitedStationsRepository _lastVisitedStationsRepository;
        private readonly IUnitOfWork _unitOfWork;


        public LastVisitedStationsBusiness(ILastVisitedStationsRepository lastVisitedStationsRepository, IUnitOfWork unitOfWork) {
            _lastVisitedStationsRepository = lastVisitedStationsRepository;
            _unitOfWork = unitOfWork;
        }

        public async void CreateUsersLog(LastVisitedStations lvs) {
            await _lastVisitedStationsRepository.CreateUsersLog(lvs);
        }

        public async Task<IEnumerable<LastVisitedStations>> GetLastVisitedStationsByUserId(Guid id) {
            try {
                var result = await _lastVisitedStationsRepository.GetLastVisitedStationsByUserId(id);
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }

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
