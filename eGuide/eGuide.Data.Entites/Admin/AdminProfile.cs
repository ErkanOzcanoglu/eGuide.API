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

        public string Username { get; set; } = string.Empty;
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordSalt { get; set; }

        //public DateTime? VerifiedAt { get; set; }
        //public string PasswordResetToken { get; set; }
        //public DateTime? PasswordResetTokenExpiresAt { get; set; }

    }
}
