using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface ICommentBusiness<T> where T: class {
        void AddComment(T comment);
        Task<IEnumerable<T>> GetAllComments();
    }
}
