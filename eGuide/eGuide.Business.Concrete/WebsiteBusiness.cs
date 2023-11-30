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
        private readonly IUnitOfWork _unitOfWork;

        public WebsiteBusiness(IGenericRepository<Website> repository, IUnitOfWork unitOfWork, IWebsiteRepository websiteRepository) : base(repository, unitOfWork) {
            _repository = websiteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Website> UpdateFooter(Website website) {
            await _repository.UpdateFooter(website);
            await _unitOfWork.CommitAsync();
            return website;
        }

        public async Task<Website> UpdateNavbar(Website website) {
            await _repository.UpdateNavbar(website);
            await _unitOfWork.CommitAsync();
            return website;
        }
    }
}
