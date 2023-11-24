using eGuide.Common.Mappers;
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
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entities.Station.StationModel&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.IStationModelRepository" />
    public class StationModelRepository: GenericRepository<StationModel>, IStationModelRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StationModelRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StationModelRepository(eGuideContext context) : base(context) {
            _context = context;
        }
    }
}
