using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Surname).IsRequired().HasMaxLength(255);
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(50);
            builder.Property(p => p.EmailAddress).IsRequired().HasMaxLength(150);

            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValue(false);




        }
    }
}
