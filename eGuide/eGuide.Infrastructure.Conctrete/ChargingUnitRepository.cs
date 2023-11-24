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

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entities.Station.ChargingUnit&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IChargingUnitRepository" />
    public class ChargingUnitRepository : GenericRepository<ChargingUnit>, IChargingUnitRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargingUnitRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ChargingUnitRepository(eGuideContext context) : base(context) {
            _context = context;
        }
    }
}
