﻿using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.CreationDto.Station {
    public class CreationDtoForStationSockets : BaseDto {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the socket identifier.
        /// </summary>
        /// <value>
        /// The socket identifier.
        /// </value>
        public Guid SocketId { get; set; }

        /// <summary>
        /// Gets or sets the station model identifier.
        /// </summary>
        /// <value>
        /// The station model identifier.
        /// </value>
        public Guid StationModelId { get; set; }
    }
}