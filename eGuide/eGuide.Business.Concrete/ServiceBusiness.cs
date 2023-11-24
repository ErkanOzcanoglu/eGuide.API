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
        private readonly IServiceRepository _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBusiness(IServiceRepository serviceRepository, IUnitOfWork unitOfWork) : base(serviceRepository, unitOfWork) {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
