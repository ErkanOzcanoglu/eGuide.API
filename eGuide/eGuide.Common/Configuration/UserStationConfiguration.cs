using eGuide.Data.Entities.Client;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration
{
    public class UserStationConfiguration
    {
        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<UserStation> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.User)
                .WithMany(builder => builder.UserStations)
                .HasForeignKey(builder => builder.UserId);

            builder.HasOne(builder => builder.StationProfile)
                .WithMany(builder => builder.UserStations)
                .HasForeignKey(builder => builder.StationProfileId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);    
        }
    }
}
