﻿using System;
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
    public class AdminProfile : BaseModel
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

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the pass word hash.
        /// </summary>
        /// <value>
        /// The pass word hash.
        /// </value>
        public byte[] PassWordHash { get; set; }

        /// <summary>
        /// Gets or sets the pass word salt.
        /// </summary>
        /// <value>
        /// The pass word salt.
        /// </value>
        public byte[] PassWordSalt { get; set; }

        /// <summary>
        /// Gets or sets the verified at.
        /// </summary>
        /// <value>
        /// The verified at.
        /// </value>
        public DateTime? VerifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the password reset token.
        /// </summary>
        /// <value>
        /// The password reset token.
        /// </value>
        public string? PasswordResetToken { get; set; }

        /// <summary>
        /// Gets or sets the reset token expires.
        /// </summary>
        /// <value>
        /// The reset token expires.
        /// </value>
        public DateTime? ResetTokenExpires { set; get; }

        /// <summary>
        /// Gets or sets the confirmation token.
        /// </summary>
        /// <value>
        /// The confirmation token.
        /// </value>
        public string? ConfirmationToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is master admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is master admin; otherwise, <c>false</c>.
        /// </value>
        public bool isMasterAdmin { get; set; }
    }
}
