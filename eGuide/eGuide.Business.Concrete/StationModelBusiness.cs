using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class StationModelBusiness : Business<StationModel>, IStationModelBusiness {
        private readonly IStationModelRepository _stationModelRepository;

        public StationModelBusiness(IStationModelRepository stationModelRepository, IUnitOfWork unitOfWork) : base(stationModelRepository, unitOfWork) {
            _stationModelRepository = stationModelRepository;
        }
    }
}
