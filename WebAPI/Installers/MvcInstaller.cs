using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            //przeniesione ze Startup
            //services.AddScoped<IPostRepository, PostReposiotry>();   //interface IPostRepository, implementacja interface PostRepository. Teraz jeżeli program napotka IPostRepository automatycznie przypisze do niej PostRepository
            //services.AddScoped<IPostService, PostService>();

            //services.AddSingleton(AutoMapperConfig.Initialize());  //metoda AddSingleton - zapwni że konf tworzona będzie tylko raz
            //Teraz gdy na wejściu (np. w parametrze konstruktora) dostanie interface IMapper to wstrzyknie implementację pochodzącą z klasy AutoMapper config
            services.AddApplication();
            services.AddInfrastructure();


            services.AddControllers();
        }
    }
}
