using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {
    public interface IWebsiteRepository : IGenericRepository<Website> {
        /// <summary>
        /// Updates the navbar.
        /// </summary>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        Task<Website> UpdateNavbar(Website website);

        /// <summary>
        /// Updates the footer.
        /// </summary>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        Task<Website> UpdateFooter(Website website);

    }
}
