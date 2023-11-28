using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Business.Interface.IBusiness&lt;eGuide.Data.Entities.Station.Facility&gt;" />
    public interface IFacilityBusiness : IBusiness<Facility> {

        Task<Facility> GetByFacilityId(Guid facilityId);
    }
}
