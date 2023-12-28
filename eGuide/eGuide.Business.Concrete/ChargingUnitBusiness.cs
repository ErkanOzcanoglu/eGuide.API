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
        private readonly IChargingUnitRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ChargingUnitBusiness(IChargingUnitRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ChargingUnit>> GetChargingUnits() {
            var res = await _repository.GetChargingUnits();
            if(res != null)
                return res;

            return null;
        }
    }
}
