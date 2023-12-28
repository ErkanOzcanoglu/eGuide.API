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

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IFacilityRepository _repository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public FacilityBusiness(IFacilityRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the by facility identifier.
        /// </summary>
        /// <param name="facilityId">The facility identifier.</param>
        /// <returns></returns>
        public async Task<Facility> GetByFacilityId(Guid facilityId)
        {
           return await _repository.GetByFacilityId(facilityId);
        }
    }
}
