using Core.Models;
using Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DAL
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>().Ignore(d => d.Photo);
            builder.ApplyConfiguration(new DoctorConfiguration());



            base.OnModelCreating(builder);
        }
    }
}
