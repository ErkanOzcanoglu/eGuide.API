using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.OutComing.Station
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Dto.OutComing.BaseDto" />
    public class StationProfileDto : BaseDto
    {

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longtitude.
        /// </summary>
        /// <value>
        /// The longtitude.
        /// </value>
        public string Longtitude { get; set; }
    }
}
