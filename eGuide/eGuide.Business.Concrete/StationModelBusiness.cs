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

        /// <summary>
        /// The station model repository
        /// </summary>
        private readonly IStationModelRepository _stationModelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationModelBusiness"/> class.
        /// </summary>
        /// <param name="stationModelRepository">The station model repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public StationModelBusiness(IStationModelRepository stationModelRepository, IUnitOfWork unitOfWork) : base(stationModelRepository, unitOfWork) {
            _stationModelRepository = stationModelRepository;
        }
    }
}
