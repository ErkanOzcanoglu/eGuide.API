using eGuide.Data.Entites.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Station
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class ChargingUnit : BaseModel
    {

        /// <summary>
        /// Gets or sets the power.
        /// </summary>
        /// <value>
        /// The power.
        /// </value>
        public string Power { get; set; }

        /// <summary>
        /// Gets or sets the voltage.
        /// </summary>
        /// <value>
        /// The voltage.
        /// </value>
        public string Voltage { get; set; }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public string Current { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>
        /// The connector.
        /// </value>
        public Connector Connector { get; set; }

        /// <summary>
        /// Gets or sets the connector identifier.
        /// </summary>
        /// <value>
        /// The connector identifier.
        /// </value>
        public Guid ConnectorId { get; set; }

        /// <summary>
        /// Gets or sets the station models.
        /// </summary>
        /// <value>
        /// The station models.
        /// </value>
        public ICollection<StationsChargingUnits> StationsChargingUnits { get; set; }
    }
}
