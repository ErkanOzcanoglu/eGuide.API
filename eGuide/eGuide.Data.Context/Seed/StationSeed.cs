using eGuide.Data.Entities.Station;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Context.Seed {
    public class StationSeed : IEntityTypeConfiguration<StationProfile> {
        public void Configure(EntityTypeBuilder<StationProfile> builder) {
            builder.HasData(
                 new StationProfile { Id = Guid.NewGuid(), Address = "Address1", Name = "Name1", Latitude = "39.28490810034864", Longitude = "32.83302000000003", StationModelId = Guid.Parse("fcd65466-6362-4ae3-bc9a-092c7aaeaeaa"), Status = 1, CreatedDate = DateTime.Now },
                 new StationProfile { Id = Guid.NewGuid(), Address = "Address2", Name = "Name2", Latitude = "39.28490810034864", Longitude = "32.83302000000003", StationModelId = Guid.Parse("4057a7c1-bab2-4c6d-96ea-dfea4a2448a8"), Status = 1, CreatedDate = DateTime.Now }
                );
        }
    }
}
