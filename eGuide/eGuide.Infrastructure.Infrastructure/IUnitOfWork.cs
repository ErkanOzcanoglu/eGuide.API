using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task CommitAsync();

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit();
    }
}
