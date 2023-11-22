using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.Logger {
    public class LastVisitedStations : BaseDto {
        public DateTime CreatedTime { get; set; }
        public Guid StationId { get; set; }
        public Guid UserId { get; set; }
    }
}
