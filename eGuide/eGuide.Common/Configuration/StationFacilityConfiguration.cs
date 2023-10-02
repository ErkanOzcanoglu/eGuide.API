using eGuide.Data.Entites.Station;
using eGuide.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration {
    public class StationFacilityConfiguration {
        public void Configure(EntityTypeBuilder<StationFacility> builder) {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.Station)
                .WithMany(builder => builder.StationFacilities)
                .HasForeignKey(builder => builder.StationId);

            builder.HasOne(builder => builder.Facility)
                .WithMany(builder => builder.StationFacilities)
                .HasForeignKey(builder => builder.FacilityId);
        }
    }
}
