using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {
    public class ConnectorRepository : GenericRepository<Connector>, IConnectorRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// The connectors
        /// </summary>
        private readonly DbSet<Connector> _connectors;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ConnectorRepository(eGuideContext context) : base(context) {
            _context = context;
            _connectors = _context.Set<Connector>();
        }

    }
}
