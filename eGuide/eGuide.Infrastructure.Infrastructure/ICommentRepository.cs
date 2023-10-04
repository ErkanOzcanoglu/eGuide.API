using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {
    public interface ICommentRepository<T> where T: class {
        Task<T> AddAsync(T comment);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
