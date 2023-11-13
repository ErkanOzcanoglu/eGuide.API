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
    public class SocketConfiguration {

        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<CharginUnit> builder) {
            builder.HasKey(builder => builder.Id);

          builder.HasOne(builder=> builder.Connector)
                .WithMany(builder=>builder.Sockets)
                .HasForeignKey(builder=>builder.ConnectorId);
        }
    }
}
