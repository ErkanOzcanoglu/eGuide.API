using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Client
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class Vehicle : BaseModel
    {

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        /// <value>
        /// The brand.
        /// </value>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the user vehicles.
        /// </summary>
        /// <value>
        /// The user vehicles.
        /// </value>
        public ICollection<UserVehicle> UserVehicles { get; set; }

        /// <summary>
        /// Gets or sets the connector identifier.
        /// </summary>
        /// <value>
        /// The connector identifier.
        /// </value>
        public Guid ConnectorId { get; set; }

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>
        /// The connector.
        /// </value>
        public Connector Connector { get; set; }
    }
}
