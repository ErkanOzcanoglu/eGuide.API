using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.UpdateDto.Client
{
    public class UpdateDtoForUserVehicle:BaseDto
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        /// <value>
        /// The vehicle identifier.
        /// </value>
        public Guid VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the connector identifier.
        /// </summary>
        /// <value>
        /// The connector identifier.
        /// </value>
        public Guid ConnectorId { get; set; }
    }
}
