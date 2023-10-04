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
        private readonly IAdminAuthorizationRepository _adminAuthorizationBusiness;


        public AdminAuthorizationBusiness(IGenericRepository<AdminProfile> repository, IUnitOfWork unitOfWork, IAdminAuthorizationRepository adminAuthorizationBusiness) : base(repository, unitOfWork)
        {
            _adminAuthorizationBusiness= adminAuthorizationBusiness;
        }

        public async Task Register(AdminProfile entity)
        {
            await _adminAuthorizationBusiness.Register(entity);
        }
    }
}
