using eGuide.Data.Entities.Admin;
using eGuide.Data.Entities.Message;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Configuration
{
    public class MessageConfiguration
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.HasKey(builder => builder.Id);
        }
    }
}
