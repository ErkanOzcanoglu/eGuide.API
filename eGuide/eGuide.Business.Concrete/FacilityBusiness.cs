using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class FacilityBusiness : Business<Facility>, IFacilityBusiness {
        private readonly IFacilityRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FacilityBusiness(IFacilityRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Facility> GetByFacilityId(Guid facilityId)
        {
           return await _repository.GetByFacilityId(facilityId);
        }
    }
}
