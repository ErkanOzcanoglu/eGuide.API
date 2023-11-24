using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Admin;
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
    /// <seealso cref="eGuide.Infrastructure.Concrete.GenericRepository&lt;eGuide.Data.Entities.Admin.SocialMedia&gt;" />
    /// <seealso cref="eGuide.Infrastructure.Interface.ISocialMediaRepository" />
    public class SocialMediaRepository : GenericRepository<SocialMedia>, ISocialMediaRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialMediaRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SocialMediaRepository(eGuideContext context) : base(context) {
            _context = context;
        }
    }
}
