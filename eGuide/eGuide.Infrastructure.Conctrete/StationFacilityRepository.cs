using eGuide.Data.Context.Context;
using eGuide.Data.Entites.Station;
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
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entites.Station.StationFacility&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IStationFacilityRepository" />
    public class StationFacilityRepository : GenericRepository<StationFacility>, IStationFacilityRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationFacilityRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StationFacilityRepository(eGuideContext context) : base(context) {
            _context = context;
        }
    }
}
