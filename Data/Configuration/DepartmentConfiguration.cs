using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Departament>
    {
        public void Configure(EntityTypeBuilder<Departament> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(255);
            builder.Property(d => d.Image).IsRequired();





            builder.Property(d => d.IsDeleted).IsRequired().HasDefaultValue(false);
        }
    }
}
