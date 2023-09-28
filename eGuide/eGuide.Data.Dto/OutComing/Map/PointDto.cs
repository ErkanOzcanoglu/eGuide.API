using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.OutComing.Map 
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class PointDto : BaseDto
    {

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public string Longitude { get; set; }
    }
}
