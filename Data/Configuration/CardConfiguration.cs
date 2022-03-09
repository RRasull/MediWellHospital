using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(c => c.Icon).IsRequired();
            builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(150);

            builder.Property(c => c.IsDeleted).IsRequired().HasDefaultValue(false);




        }
    }
}
