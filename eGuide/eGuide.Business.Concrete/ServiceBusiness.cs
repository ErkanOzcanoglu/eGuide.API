using eGuide.Business.Interface;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class ServiceBusiness : Business<Services>, IServiceBusiness {

        /// <summary>
        /// The service repository
        /// </summary>
        private readonly IServiceRepository _serviceRepository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBusiness"/> class.
        /// </summary>
        /// <param name="serviceRepository">The service repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ServiceBusiness(IServiceRepository serviceRepository, IUnitOfWork unitOfWork) : base(serviceRepository, unitOfWork) {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
