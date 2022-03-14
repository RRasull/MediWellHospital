using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Profiles
{
   public static class MapperServiceExtention
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapper());
            }).CreateMapper());
        }
    }
}
