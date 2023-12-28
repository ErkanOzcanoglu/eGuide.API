using eGuide.Business.Interface;
using eGuide.Data.Dto.Logger;
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
    /// <seealso cref="eGuide.Business.Interface.ILogBusiness" />
    public class LogBusiness : ILogBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly ILogRepository _repository;
        
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;


        /// <summary>
        /// Initializes a new instance of the <see cref="LogBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public LogBusiness(ILogRepository repository, IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets all asynchronous log.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserLogs>> GetAllAsyncLog() {
            return await _repository.GetAllAsyncLog();
        }

        /// <summary>
        /// Creates the users log.
        /// </summary>
        /// <param name="comment">The comment.</param>
        /// <returns></returns>
        public async Task<UserLogs> CreateUsersLog(UserLogs comment) {
            return await _repository.CreateUsersLog(comment);
        }

        public async Task<IEnumerable<UserLogs>> GetErrorLogs() {
            return await _repository.GetErrorLogs();
        }

        public async Task<IEnumerable<UserLogs>> GetInfoLogs() {
            return await _repository.GetInfoLogs();
        }
    }
}
