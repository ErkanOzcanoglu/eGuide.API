using eGuide.Data.Entities;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entites.Station {
    public class StationFacility : BaseModel {
        public Guid StationId { get; set; }
        public StationProfile Station { get; set; }
        public Guid FacilityId { get; set; }
        public Facility Facility { get; set; }
    }
}
