using eGuide.Data.Entities.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration
{
    public class UserVehicleConfiguration 
    {
        public void Configure(EntityTypeBuilder<UserVehicle> builder)
        {
            builder.HasKey(builder => builder.Id);

            builder.HasOne(builder => builder.User)
                .WithMany(builder => builder.UserVehicles)
                .HasForeignKey(builder => builder.UserId);

            builder.HasOne(builder => builder.Vehicle)
                .WithMany(builder => builder.UserVehicles)
                .HasForeignKey(builder => builder.VehicleId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


        }
    }
}
