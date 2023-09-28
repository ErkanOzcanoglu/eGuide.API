using eGuide.Data.Entities.Map;
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
    public class RouteConfiguration {

        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<Route> builder) {

            builder.HasKey(builder => builder.Id);
        }
    }
}
