using eGuide.Data.Entites.Client;
using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Client
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class User : BaseModel
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
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Gets or sets the stations.
        /// </summary>
        /// <value>
        /// The stations.
        /// </value>
        public ICollection<StationProfile> Stations { get; set; }

        /// <summary>
        /// Gets or sets the user vehicles.
        /// </summary>
        /// <value>
        /// The user vehicles.
        /// </value>
        public ICollection<UserVehicle> UserVehicles { get; set; }

        public byte[] PassWordHash { get; set; }
        public byte[] PassWordSalt { get; set; }

        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { set; get; }

        public string? ConfirmationToken { get; set; }
    }
        
}
