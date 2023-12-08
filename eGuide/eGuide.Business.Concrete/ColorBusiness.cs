using eGuide.Business.Interface;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Concrete {
    public class ColorBusiness : Business<Color>, IColorBusiness {

        /// <summary>
        /// The repository
        /// </summary>
        private readonly IColorRepository _repository;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorBusiness"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ColorBusiness(IColorRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

    }
}
