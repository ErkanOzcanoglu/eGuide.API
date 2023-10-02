using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.OutComing.Admin
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class AdminProfileDto : BaseDto
    {

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }

    }
}
