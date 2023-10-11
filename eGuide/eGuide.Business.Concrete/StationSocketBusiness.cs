using eGuide.Business.Interface;
using eGuide.Data.Entites.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class StationSocketBusiness : Business<StationSockets>, IStationSocketBusiness {
        private readonly IStationSocketRepository _stationSocketRepository;

        public StationSocketBusiness(IStationSocketRepository stationSocketRepository, IUnitOfWork unitOfWork) : base(stationSocketRepository, unitOfWork) {
            _stationSocketRepository = stationSocketRepository;
        }
    }
}
