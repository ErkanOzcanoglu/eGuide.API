using eGuide.Data.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Station
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class StationProfile : BaseModel
    {

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longtitude.
        /// </summary>
        /// <value>
        /// The longtitude.
        /// </value>
        public string Longtitude { get; set; }

        /// <summary>
        /// Gets or sets the station model identifier.
        /// </summary>
        /// <value>
        /// The station model identifier.
        /// </value>
        public Guid StationModelId { get; set; }

        /// <summary>
        /// Gets or sets the station model.
        /// </summary>
        /// <value>
        /// The station model.
        /// </value>
        public StationModel StationModel { get; set; }

        /// <summary>
        /// Gets or sets the facilities.
        /// </summary>
        /// <value>
        /// The facilities.
        /// </value>
        public ICollection<Facility> Facilities { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public ICollection<Comment> Comments { get; set; }
    }
}
