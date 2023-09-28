using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.UpdateDto.Station 
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Dto.OutComing.BaseDto" />
    public class UpdateDtoForSocket : BaseDto
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
    }
}
