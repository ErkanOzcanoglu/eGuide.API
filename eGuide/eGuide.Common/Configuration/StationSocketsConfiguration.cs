using eGuide.Data.Entites.Station;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration {
    public class StationSocketsConfiguration {
        public void Configure(EntityTypeBuilder<StationsChargingUnits> builder) {
            builder.HasKey(builder => builder.Id);


            builder.HasOne(builder => builder.CharginUnit)
                .WithMany(builder => builder.StationsChargingUnits)
                .HasForeignKey(builder => builder.SocketId);

            builder.HasOne(builder => builder.StationModel)
                .WithMany(builder => builder.StationsChargingUnits)
                .HasForeignKey(builder => builder.StationModelId);
        }
    }
}
