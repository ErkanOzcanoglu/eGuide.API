using eGuide.Business.Interface;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Business.Concrete.Business&lt;eGuide.Data.Entities.Station.Connector&gt;" />
    /// <seealso cref="eGuide.Business.Interface.IConnectorBusiness" />
    public class ConnectorBusiness : Business<Connector>, IConnectorBusiness {

        /// <summary>
        /// The connector repository
        /// </summary>
        private readonly IConnectorRepository _connectorRepository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorBusiness"/> class.
        /// </summary>
        /// <param name="connectorRepository">The connector repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ConnectorBusiness(IConnectorRepository connectorRepository, IUnitOfWork unitOfWork) : base(connectorRepository, unitOfWork) {
            _connectorRepository = connectorRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the con.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Connector>> GetCon() {
            var re = await _connectorRepository.GetCons();
            return re;
        }
    }
}
