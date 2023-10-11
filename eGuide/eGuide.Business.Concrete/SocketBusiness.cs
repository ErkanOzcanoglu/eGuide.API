using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class SocketBusiness : Business<Socket>, ISocketBusiness {
        private readonly ISocketRepository _socketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SocketBusiness(ISocketRepository socketRepository, IUnitOfWork unitOfWork) : base(socketRepository, unitOfWork) {
            _socketRepository = socketRepository;
            _unitOfWork = unitOfWork;
        }
    }
}
