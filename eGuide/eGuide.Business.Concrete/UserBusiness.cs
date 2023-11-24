using eGuide.Business.Interface;
using eGuide.Data.Dto.Logger;
using eGuide.Data.Entities.Client;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Business.Concrete.Business&lt;eGuide.Data.Entities.Client.User&gt;" />
    /// <seealso cref="eGuide.Business.Interface.IUserBusiness" />
    public class UserBusiness : Business<User>, IUserBusiness {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userRepository">The user repository.</param>
        public UserBusiness(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async void AddUsersLogs(UserLogs user) {
            await _userRepository.CreateUsersLog(user);
        }

        public async Task<IEnumerable<UserLogs>> GetAllLogs() {
            return await _userRepository.GetAllAsyncLog();
        }
    }
}
