using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.UpdateDto.Client 
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseDto" />
    public class UpdateDtoForPoint : BaseDto
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
