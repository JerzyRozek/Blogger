﻿using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
 public static   class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IPostService, PostService>();

         //   services.AddSingleton(AutoMapperConfig.Initialize());  //metoda AddSingleton - zapwni że konf tworzona będzie tylko raz

            return services;
        }
    }
}
