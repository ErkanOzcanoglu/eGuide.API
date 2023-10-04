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
    public class AdminAuthorizationBusiness : Business<AdminProfile> , IAdminAuthorizationBusiness
    {
        /// <summary>
        /// The admin authorization business
        /// </summary>
        private readonly IAdminAuthorizationRepository _adminAuthorizationBusiness;


        /// <summary>
        /// Initializes a new instance of the <see cref="AdminAuthorizationBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="adminAuthorizationBusiness">The admin authorization business.</param>
        public AdminAuthorizationBusiness(IGenericRepository<AdminProfile> repository, IUnitOfWork unitOfWork, IAdminAuthorizationRepository adminAuthorizationBusiness) : base(repository, unitOfWork)
        {
            _adminAuthorizationBusiness= adminAuthorizationBusiness;
        }

        /// <summary>
        /// Registers the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public async Task Register(AdminProfile entity)
        {
            await _adminAuthorizationBusiness.Register(entity);
        }
    }
}
