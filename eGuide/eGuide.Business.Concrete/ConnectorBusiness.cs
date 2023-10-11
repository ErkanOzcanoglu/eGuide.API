using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class ConnectorBusiness : Business<Connector>, IConnectorBusiness {
        private readonly IConnectorRepository _connectorRepository;

        public ConnectorBusiness(IConnectorRepository connectorRepository, IUnitOfWork unitOfWork) : base(connectorRepository, unitOfWork) {
            _connectorRepository = connectorRepository;
        }

    }
}
