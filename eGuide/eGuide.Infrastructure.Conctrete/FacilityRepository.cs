using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entities.Station.Facility&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IFacilityRepository" />
    public class FacilityRepository : GenericRepository<Facility>, IFacilityRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacilityRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public FacilityRepository(eGuideContext context) : base(context) {
            _context = context;
        }
    }
}
