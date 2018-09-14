using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ToDoService.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace ToDoService
{
    using Services;
    using BusinessLogic;
    using ToDoService.DAL.Repositories.Interfaces;
    using ToDoService.DAL.Repositories;
    // using ProviderService.BusinessLogic.Interfaces;

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
            services.AddDbContext<ToDoContext>(opt => 
                //String goes in config, or pulled from a DB
                opt.UseSqlite("Data Source=ToDo.db")
                );

            services.AddScoped<ToDoService>();
            // services.AddTransient<IPhysicianProvider, PhysicianProvider>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
