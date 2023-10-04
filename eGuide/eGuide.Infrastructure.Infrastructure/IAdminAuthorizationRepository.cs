using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface
{
    public interface IAdminAuthorizationRepository : IGenericRepository<AdminProfile>
    {
        Task Register(AdminProfile entity);
    }
}
