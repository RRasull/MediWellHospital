using Business.Implementations;
using Business.Interfaces;
using Core;
using Core.Models;
using Data;
using Data.DAL;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MediWellHospital
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IWelcomeService, WelcomeService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IPatientService, PatientService>();


            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));

            services.Configure<IdentityOptions>(identityOptions =>
            {
                identityOptions.Password.RequiredLength = 8;
                identityOptions.Password.RequireNonAlphanumeric = true;
                identityOptions.Password.RequireUppercase = true;
                identityOptions.Password.RequireLowercase = true;
                identityOptions.Password.RequireDigit = true;

                identityOptions.User.RequireUniqueEmail = true;

                //identityOptions.Lockout.MaxFailedAccessAttempts = 3;
                //identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                //identityOptions.Lockout.AllowedForNewUsers = true;

                identityOptions.SignIn.RequireConfirmedEmail = true;


            })
                ;

            services.AddAuthentication()
                    .AddGoogle(options => {
                        options.ClientId = "489592843078-n74lkl4c0pmkeh06qouo4842pbuitno2.apps.googleusercontent.com";
                        options.ClientSecret = "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";
                    });
                    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
