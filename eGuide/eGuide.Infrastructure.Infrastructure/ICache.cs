using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Cache.Interface {

    /// <summary>
    /// 
    /// </summary>
    public interface ICache {

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T GetData<T>(string key);

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expirationTime">The expiration time.</param>
        /// <returns></returns>
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);

        /// <summary>
        /// Removes the data.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        object RemoveData(string key);
    }
}
