using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(s => s.Key).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Value).IsRequired().HasMaxLength(255);
            builder.Property(s => s.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
