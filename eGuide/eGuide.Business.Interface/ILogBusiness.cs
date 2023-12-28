using eGuide.Data.Dto.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface ILogBusiness {
        Task<UserLogs> CreateUsersLog(UserLogs comment);
        Task<IEnumerable<UserLogs>> GetAllAsyncLog();
        Task<IEnumerable<UserLogs>> GetErrorLogs();
        Task<IEnumerable<UserLogs>> GetInfoLogs();
    }
}
