using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using eGuide.Cache.Interface;
using StackExchange.Redis;

namespace eGuide.Cache.Concrete {
    public class Cache : ICache {
        private IDatabase _cacheDb;

        public Cache() {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }

        public T GetData<T>(string key) {
            var value = _cacheDb.StringGet(key);
            if (!string.IsNullOrEmpty(value)) {
                // Use JsonSerializerSettings to handle circular references
                var settings = new JsonSerializerOptions {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                };

                return JsonSerializer.Deserialize<T>(value, settings);
            } else {
                return default;
            }
        }

        public object RemoveData(string key) {
            var exists = _cacheDb.KeyExists(key);
            if (exists) {
                return _cacheDb.KeyDelete(key);
            } else {
                return false;
            }
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime) {
            var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);

            // Use JsonSerializerSettings to handle circular references
            var settings = new JsonSerializerOptions {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
            };

            var serializedValue = JsonSerializer.Serialize(value, settings);

            return _cacheDb.StringSet(key, serializedValue, expiryTime);
        }
    }
}
