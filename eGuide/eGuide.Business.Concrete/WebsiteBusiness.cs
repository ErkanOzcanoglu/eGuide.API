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
    public class WebsiteBusiness : Business<Website> , IWebsiteBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IWebsiteRepository _repository;

        public WebsiteBusiness(IGenericRepository<Website> repository, IUnitOfWork unitOfWork, IWebsiteRepository websiteRepository) : base(repository, unitOfWork) {
            _repository = websiteRepository;
        }
    }
}
