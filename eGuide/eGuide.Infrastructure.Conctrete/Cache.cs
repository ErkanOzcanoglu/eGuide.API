﻿using eGuide.Cache.Interface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eGuide.Cache.Concrete {
    public class Cache : ICache {

        /// <summary>
        /// The cache database
        /// </summary>
        private IDatabase _cacheDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cache" /> class.
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
                return JsonSerializer.Deserialize<T>(value);
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
            var _exist = _cacheDb.KeyExists(key);
            if (_exist) {
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
            return _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expiryTime);
        }
    }
}
