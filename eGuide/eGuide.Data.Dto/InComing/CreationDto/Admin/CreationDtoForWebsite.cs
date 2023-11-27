﻿using eGuide.Data.Dto.OutComing;
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
    /// <seealso cref="eGuide.Data.Dto.OutComing.BaseDto" />
    public class CreationDtoForWebsite: BaseDto
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

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
