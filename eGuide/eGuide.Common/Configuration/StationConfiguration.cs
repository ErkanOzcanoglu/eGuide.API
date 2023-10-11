using eGuide.Data.Entities.Station;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration {

    /// <summary>
    /// 
    /// </summary>
    public class StationConfiguration {

        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<StationProfile> builder) 
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.StationSockets)
                .WithMany(builder => builder.Stations)
                .HasForeignKey(builder=> builder.StationSocketsId);
        }
    }
}
