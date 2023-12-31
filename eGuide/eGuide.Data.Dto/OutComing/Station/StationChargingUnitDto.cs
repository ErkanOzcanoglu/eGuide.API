﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.OutComing.Station {
    public class StationChargingUnitDto {

        /// <summary>
        /// Gets or sets the station model identifier.
        /// </summary>
        /// <value>
        /// The station model identifier.
        /// </value>
        public Guid StationModelId { get; set; }

        /// <summary>
        /// Gets or sets the socket identifier.
        /// </summary>
        /// <value>
        /// The socket identifier.
        /// </value>
        public Guid ChargingUnitId { get; set; }
    }
}
