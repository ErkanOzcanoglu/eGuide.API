using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entities.Admin.Service&gt;" />
    public interface IServiceRepository : IGenericRepository<Services> {
    }
}
