using eGuide.Business.Interface;
using eGuide.Data.Entities.Admin;
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
    /// <seealso cref="eGuide.Business.Concrete.Business&lt;eGuide.Data.Entities.Admin.Website&gt;" />
    /// <seealso cref="eGuide.Business.Interface.IWebsiteBusiness" />
    public class WebsiteBusiness : Business<Website>, IWebsiteBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IWebsiteRepository _repository;
        
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="websiteRepository">The website repository.</param>
        public WebsiteBusiness(IGenericRepository<Website> repository, IUnitOfWork unitOfWork, IWebsiteRepository websiteRepository) : base(repository, unitOfWork) {
            _repository = websiteRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Updates the footer.
        /// </summary>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        public async Task<Website> UpdateFooter(Website website) {
            await _repository.UpdateFooter(website);
            await _unitOfWork.CommitAsync();
            return website;
        }

        /// <summary>
        /// Updates the navbar.
        /// </summary>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        public async Task<Website> UpdateNavbar(Website website) {
            await _repository.UpdateNavbar(website);
            await _unitOfWork.CommitAsync();
            return website;
        }
    }
}
