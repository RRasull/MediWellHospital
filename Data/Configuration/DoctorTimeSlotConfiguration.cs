using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class DoctorTimeSlotConfiguration : IEntityTypeConfiguration<DoctorTimeSlot>
    {
        public void Configure(EntityTypeBuilder<DoctorTimeSlot> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(255);
            builder.Property(d => d.ToTime).IsRequired();
            builder.Property(d => d.FromTime).IsRequired();

            builder.Property(d => d.IsActive).IsRequired().HasDefaultValue(false);




        }
    }
}
