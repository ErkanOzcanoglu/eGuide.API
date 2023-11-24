using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.CreationDto.Admin 
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseDto" />
    public class CreationDtoForSocialMedia : BaseDto
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the icon alt.
        /// </summary>
        /// <value>
        /// The icon alt.
        /// </value>
        public string IconAlt { get; set; }
    }
}
