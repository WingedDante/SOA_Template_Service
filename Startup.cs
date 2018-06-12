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
using ProviderService.data.contexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace ProviderService
{
    using Services;
    using BusinessLogic;
    using ProviderService.data.Repositories.Interfaces;
    using ProviderService.data.Repositories;
    using ProviderService.BusinessLogic.Interfaces;

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
            services.AddDbContext<ProviderContext>(opt => 
                //String goes in config, or pulled from a DB
                opt.UseSqlServer("Server=d-wbdb01-aultcare.database.windows.net,1433; Initial Catalog=ACProvDir;Persist Security Info=False;User ID=ProvDirUser;Password=vOTQ%R!fE$33u!1X;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;")
                );

            services.AddScoped<ProvidersService>();
            services.AddTransient<IPhysicianProvider, PhysicianProvider>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
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
