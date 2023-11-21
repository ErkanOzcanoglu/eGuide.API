using eGuide.Data.Dto.Log;
using eGuide.Data.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Business.Interface.IBusiness&lt;eGuide.Data.Entities.Client.User&gt;" />
    public interface IUserBusiness : IBusiness<User>
    {
        void AddUsersLogs(UserLogs user);
        Task<IEnumerable<UserLogs>> GetAllLogs();
    }
}
