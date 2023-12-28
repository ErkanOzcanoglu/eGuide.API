using eGuide.Data.Dto.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {
    public interface ILogRepository {
        /// <summary>
        /// Creates the users log.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        Task<UserLogs> CreateUsersLog(UserLogs comment);

        /// <summary>
        /// Gets all asynchronous log.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserLogs>> GetAllAsyncLog();

        /// <summary>
        /// Gets the error logs.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserLogs>> GetErrorLogs();

        /// <summary>
        /// Gets the information logs.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserLogs>> GetInfoLogs();
    }
}
