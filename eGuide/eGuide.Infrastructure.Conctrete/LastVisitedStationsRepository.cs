using eGuide.Data.Dto.Logger;
using eGuide.Data.Entities.Station;
using eGuide.Infrastructure.Interface;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {
    public class LastVisitedStationsRepository : ILastVisitedStationsRepository {

        /// <summary>
        /// The collection
        /// </summary>
        private readonly IMongoCollection<LastVisitedStations> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="LastVisitedStationsRepository"/> class.
        /// </summary>
        /// <param name="mongoContext">The mongo context.</param>
        public LastVisitedStationsRepository(IMongoDatabase mongoContext) {
            _collection = mongoContext.GetCollection<LastVisitedStations>("LastVisitedStations");
        }

        /// <summary>
        /// Creates the users log.
        /// </summary>
        /// <param name="lvs">The LVS.</param>
        /// <returns></returns>
        public async Task<LastVisitedStations> CreateUsersLog(LastVisitedStations lvs) {
            lvs.Id = Guid.NewGuid();
            lvs.CreatedTime = DateTime.Now;

            // "expiryDate" adlı bir alanı kullanarak TTL endeksi oluşturun
            var keys = Builders<LastVisitedStations>.IndexKeys.Ascending(x => x.CreatedTime);
            var options = new CreateIndexOptions { ExpireAfter = TimeSpan.FromDays(30) };
            var indexModel = new CreateIndexModel<LastVisitedStations>(keys, options);

            // Koleksiyona TTL endeksini ekleyin
            await _collection.Indexes.CreateOneAsync(indexModel);

            // Belgeyi koleksiyona ekleyin
            await _collection.InsertOneAsync(lvs);

            return lvs;
        }

        /// <summary>
        /// Gets the last visited stations by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IEnumerable<LastVisitedStations>> GetLastVisitedStationsByUserId(Guid id) {
            return Task.FromResult(_collection.Find(x => x.UserId == id).ToList().AsEnumerable());
        }

        /// <summary>
        /// Removes the last visited station.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<LastVisitedStations> RemoveLastVisitedStation(Guid id) {
            var result = await _collection.FindOneAndDeleteAsync(x => x.Id == id);
            return result;
        }
    }
}
