using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.CreationDto.Station {
    public class CreationDtoForStationChargingUnit : BaseDto {

        /// <summary>
        /// Gets or sets the socket identifier.
        /// </summary>
        /// <value>
        /// The socket identifier.
        /// </value>
        public Guid ChargingUnitId { get; set; }

        /// <summary>
        /// Gets or sets the station profile identifier.
        /// </summary>
        /// <value>
        /// The station profile identifier.
        /// </value>
        public Guid StationModelId { get; set; }
    }
}
