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
    public class StationModel : BaseModel
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stations.
        /// </summary>
        /// <value>
        /// The stations.
        /// </value>
        public ICollection<StationProfile> Stations { get; set; }

        /// <summary>
        /// Gets or sets the station sockets.
        /// </summary>
        /// <value>
        /// The station sockets.
        /// </value>
        public ICollection<StationSockets> StationSockets { get; set; }

    }
}
