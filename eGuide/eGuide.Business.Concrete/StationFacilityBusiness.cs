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
        private readonly IStationFacilityRepository _stationFacilityRepository;

        public StationFacilityBusiness(IStationFacilityRepository stationFacilityRepository, IUnitOfWork unitOfWork) : base(stationFacilityRepository, unitOfWork) {
            _stationFacilityRepository = stationFacilityRepository;
        }
    }
}
