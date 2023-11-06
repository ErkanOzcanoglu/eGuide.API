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
        private readonly IStationRepository _stationRepository;

        public StationBusiness(IStationRepository stationRepository, IUnitOfWork unitOfWork) : base(stationRepository, unitOfWork) {
            _stationRepository = stationRepository;
        }

        public async Task<List<StationProfile>> GetAllStationInformation() {
            var result = await _stationRepository.GetAllStationInformation();
            return result;
        }
    }
}
