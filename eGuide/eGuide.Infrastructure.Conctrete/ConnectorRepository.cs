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
        private readonly eGuideContext _context;
        private readonly DbSet<Connector> _connectors;

        public ConnectorRepository(eGuideContext context) : base(context) {
            _context = context;
            _connectors = _context.Set<Connector>();
        }
    }
}
