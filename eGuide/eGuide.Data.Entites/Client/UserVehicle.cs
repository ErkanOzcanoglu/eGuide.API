using eGuide.Data.Entities;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entites.Client
{
    public class UserVehicle:BaseModel
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

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the vehicle.
        /// </summary>
        /// <value>
        /// The vehicle.
        /// </value>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>
        /// The connector.
        /// </value>
        public Connector Connector { get; set; }

    }
}
