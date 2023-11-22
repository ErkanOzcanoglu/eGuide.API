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
        private readonly IMongoCollection<LastVisitedStations> _collection;

        public LastVisitedStationsRepository(IMongoDatabase mongoContext) {
            _collection = mongoContext.GetCollection<LastVisitedStations>("LastVisitedStations");
        }

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


        public Task<IEnumerable<LastVisitedStations>> GetLastVisitedStationsByUserId(Guid id) {
            return Task.FromResult(_collection.Find(x => x.UserId == id).ToList().AsEnumerable());
        }

        public async Task<LastVisitedStations> RemoveLastVisitedStation(Guid id) {
            var result = await _collection.FindOneAndDeleteAsync(x => x.Id == id);
            return result;
        }
    }
}
