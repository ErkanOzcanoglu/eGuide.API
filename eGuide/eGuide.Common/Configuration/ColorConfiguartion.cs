using eGuide.Data.Entities.Admin;
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
    public class ColorConfiguartion {

        /// <summary>
        /// Configures the specified builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public void Configure(EntityTypeBuilder<Color> builder) {
            builder.HasKey(builder => builder.Id);
        }
    }
}
