using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Admin
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class Website : BaseModel
    {

        /// <summary>
        /// Gets or sets the navbar.
        /// </summary>
        /// <value>
        /// The navbar.
        /// </value>
        public int Navbar { get; set; }

        /// <summary>
        /// Gets or sets the footer.
        /// </summary>
        /// <value>
        /// The footer.
        /// </value>
        public int Footer { get; set; }
    }
}
