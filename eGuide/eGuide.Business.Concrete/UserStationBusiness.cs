using eGuide.Business.Interface;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete
{
    public class UserStationBusiness : Business<UserStation>, IUserStationBusiness
    {
        /// <summary>
        /// The user station repository
        /// </summary>
        private readonly IUserStationRepository _userStationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserStationBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="userStationRepository">The user station repository.</param>
        public UserStationBusiness(IGenericRepository<UserStation> repository, IUnitOfWork unitOfWork, IUserStationRepository userStationRepository) : base(repository, unitOfWork)
        {
            _userStationRepository = userStationRepository;
        }

        /// <summary>
        /// Gets the user stations profiles asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<List<StationProfile>> GetUserStationsProfilesAsync(Guid userId)
        {
            return await _userStationRepository.GetUserStationsProfilesAsync(userId);
        }
    
    }
}
