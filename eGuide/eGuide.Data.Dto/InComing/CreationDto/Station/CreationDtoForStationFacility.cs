using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.CreationDto.Station {
    public class CreationDtoForStationFacility : BaseDto {
        public Guid StationId { get; set; }
        public Guid FacilityId { get; set; }
    }
}
