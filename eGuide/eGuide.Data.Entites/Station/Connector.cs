using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Client;
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
    public class Connector : BaseModel
    {

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <value>
        /// The name of the image.
        /// </value>
        public string ImageName { get; set; }
        /// <summary>
        /// Gets or sets the image data.
        /// </summary>
        /// <value>
        /// The image data.
        /// </value>
        public string ImageData { get; set; }

        /// <summary>
        /// Gets or sets the sockets.
        /// </summary>
        /// <value>
        /// The sockets.
        /// </value>
        public ICollection<ChargingUnit> Sockets { get; set; }

        /// <summary>
        /// Gets or sets the user vehicles.
        /// </summary>
        /// <value>
        /// The user vehicles.
        /// </value>
        public ICollection<UserVehicle> UserVehicles { get; set; }

    }
}
