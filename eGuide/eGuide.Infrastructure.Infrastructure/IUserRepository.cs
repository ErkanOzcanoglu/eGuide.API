﻿using eGuide.Data.Dto.Logs;
using eGuide.Data.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eGuide.Infrastructure.Interface
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Infrastructure.Interface.IGenericRepository&lt;eGuide.Data.Entities.Client.User&gt;" />
    public interface IUserRepository: IGenericRepository<User> {
        Task<UserLogs> CreateUsersLog(UserLogs comment);
        Task<IEnumerable<UserLogs>> GetAllAsyncLog();
    }
}
