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
    /// <seealso cref="eGuide.Business.Concrete.Business&lt;eGuide.Data.Entities.Admin.SocialMedia&gt;" />
    /// <seealso cref="eGuide.Business.Interface.ISocialMediaBusiness" />
    public class SocialMediaBusiness : Business<SocialMedia>, ISocialMediaBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISocialMediaRepository _repository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="SocialMediaBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public SocialMediaBusiness(ISocialMediaRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
    }
}
