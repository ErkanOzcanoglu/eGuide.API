using eGuide.Data.Entites.Station;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration {
    public class StationSocketsConfiguration {
        public void Configure(EntityTypeBuilder<StationSockets> builder) {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.StationModel)
                .WithMany(builder => builder.StationSockets)
                .HasForeignKey(builder => builder.StationModelId);

            builder.HasOne(builder => builder.Socket)
                .WithMany(builder => builder.StationSockets)
                .HasForeignKey(builder => builder.SocketId);
        }
    }
}
