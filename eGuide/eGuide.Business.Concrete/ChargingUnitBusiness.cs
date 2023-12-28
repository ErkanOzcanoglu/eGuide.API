using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class ChargingUnitBusiness : Business<ChargingUnit>, IChargingUnitBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IChargingUnitRepository _repository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargingUnitBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ChargingUnitBusiness(IChargingUnitRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the charging units.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ChargingUnit>> GetChargingUnits() {
            var res = await _repository.GetChargingUnits();
            if(res != null)
                return res;

            return null;
        }
    }
}
