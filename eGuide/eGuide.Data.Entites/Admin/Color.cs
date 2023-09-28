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
    public class Color : BaseModel
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the light color1.
        /// </summary>
        /// <value>
        /// The light color1.
        /// </value>
        public string LightColor1 { get; set; }

        /// <summary>
        /// Gets or sets the light color2.
        /// </summary>
        /// <value>
        /// The light color2.
        /// </value>
        public string LightColor2 { get; set; }

        /// <summary>
        /// Gets or sets the light color3.
        /// </summary>
        /// <value>
        /// The light color3.
        /// </value>
        public string LightColor3 { get; set; }

        /// <summary>
        /// Gets or sets the light color4.
        /// </summary>
        /// <value>
        /// The light color4.
        /// </value>
        public string LightColor4 { get; set; }

        /// <summary>
        /// Gets or sets the light color5.
        /// </summary>
        /// <value>
        /// The light color5.
        /// </value>
        public string LightColor5 { get; set; }

        /// <summary>
        /// Gets or sets the dark color1.
        /// </summary>
        /// <value>
        /// The dark color1.
        /// </value>
        public string DarkColor1 { get; set; }

        /// <summary>
        /// Gets or sets the dark color2.
        /// </summary>
        /// <value>
        /// The dark color2.
        /// </value>
        public string DarkColor2 { get; set; }

        /// <summary>
        /// Gets or sets the dark color3.
        /// </summary>
        /// <value>
        /// The dark color3.
        /// </value>
        public string DarkColor3 { get; set; }

        /// <summary>
        /// Gets or sets the dark color4.
        /// </summary>
        /// <value>
        /// The dark color4.
        /// </value>
        public string DarkColor4 { get; set; }

        /// <summary>
        /// Gets or sets the dark color5.
        /// </summary>
        /// <value>
        /// The dark color5.
        /// </value>
        public string DarkColor5 { get; set; }
    }
}
