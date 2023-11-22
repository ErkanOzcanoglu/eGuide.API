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
        private readonly IUserStationRepository _userStationRepository;

        public UserStationBusiness(IGenericRepository<UserStation> repository, IUnitOfWork unitOfWork, IUserStationRepository userStationRepository) : base(repository, unitOfWork)
        {
            _userStationRepository = userStationRepository;
        }

        public async Task<List<StationProfile>> GetUserStationsProfilesAsync(Guid userId)
        {
            return await _userStationRepository.GetUserStationsProfilesAsync(userId);
        }
    
    }
}
