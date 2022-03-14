using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(255);
            builder.Property(d => d.Surname).IsRequired().HasMaxLength(255);
            builder.Property(d => d.Phone).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Surname).IsRequired().HasMaxLength(255);
            builder.Property(d => d.Address).IsRequired().HasMaxLength(255);
            builder.Property(d => d.EmailAddress).IsRequired().HasMaxLength(150);
            builder.Property(d => d.Image).IsRequired();
            builder.Ignore(d => d.Photo);
            builder.Property(d => d.Description).IsRequired().HasMaxLength(255);
            builder.Property(d => d.IsAvailable).IsRequired();
            




            builder.Property(d => d.IsDeleted).IsRequired().HasDefaultValue(false);






        }
    }
}
