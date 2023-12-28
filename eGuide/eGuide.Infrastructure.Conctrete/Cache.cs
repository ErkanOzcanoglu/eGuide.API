using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using eGuide.Cache.Interface;
using StackExchange.Redis;

namespace eGuide.Cache.Concrete {
    public class Cache : ICache {

        /// <summary>
        /// The cache database
        /// </summary>
        private IDatabase _cacheDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cache"/> class.
        /// </summary>
        public Cache() {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _cacheDb = redis.GetDatabase();
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Removes the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object RemoveData(string key) {
            var exists = _cacheDb.KeyExists(key);
            if (exists) {
                return _cacheDb.KeyDelete(key);
            } else {
                return false;
            }
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expirationTime">The expiration time.</param>
        /// <returns></returns>
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
