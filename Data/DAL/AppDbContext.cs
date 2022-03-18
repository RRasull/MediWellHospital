using Core.Models;
using Data.Configuration;
using Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorTimeSlot> DoctorTimeSlots { get; set; }

        public DbSet<Welcome> Welcome { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Card> Cards { get; set; }
        public DbSet<PatientComment> PatientComments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>().Ignore(d => d.Photo);
            builder.ApplyConfiguration(new DoctorConfiguration());

            builder.Entity<Departament>().Ignore(d => d.Photo);
            builder.ApplyConfiguration(new DepartmentConfiguration());

            builder.ApplyConfiguration(new AppointmentConfiguration());


            builder.Entity<Patient>().Ignore(d => d.Photo);
            builder.ApplyConfiguration(new PatientConfiguration());

            builder.ApplyConfiguration(new DoctorTimeSlotConfiguration());

            builder.ApplyConfiguration(new SettingConfiguration());

            builder.ApplyConfiguration(new WelcomeConfiguration());

            builder.ApplyConfiguration(new CardConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
