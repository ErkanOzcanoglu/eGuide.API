using eGuide.Business.Interface;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete
{
    public class AdminProfileBusiness: Business<AdminProfile>, IAdminProfileBusiness
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IAdminProfileRepository _adminRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userRepository">The user repository.</param>
        public AdminProfileBusiness(IGenericRepository<AdminProfile> repository, IUnitOfWork unitOfWork, IAdminProfileRepository adminRepository) : base(repository, unitOfWork)
        {
            _adminRepository = adminRepository;
        }
    }
}
