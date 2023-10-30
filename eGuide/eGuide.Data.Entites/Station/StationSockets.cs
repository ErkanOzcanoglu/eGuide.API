using eGuide.Data.Entities;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Station {
    public class StationSockets : BaseModel {

        /// <summary>
        /// Gets or sets the socket identifier.
        /// </summary>
        /// <value>
        /// The socket identifier.
        /// </value>
        public Guid SocketId { get; set; }

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public Socket Socket { get; set; }

        /// <summary>
        /// Gets or sets the station model identifier.
        /// </summary>
        /// <value>
        /// The station model identifier.
        /// </value>
        public Guid StationModelId { get; set; }

        /// <summary>
        /// Gets or sets the station model.
        /// </summary>
        /// <value>
        /// The station model.
        /// </value>
        public StationModel StationModel { get; set; }
    }
}
