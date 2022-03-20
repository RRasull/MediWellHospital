using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(d => d.PatientMessage).IsRequired();
            builder.Property(d => d.PatientPhone).IsRequired();
            builder.Property(d => d.AppointDate).IsRequired();
            builder.Property(d => d.DoctorId).IsRequired();


            builder.Property(d => d.IsDeleted).IsRequired().HasDefaultValue(false);

        }
    }
}
