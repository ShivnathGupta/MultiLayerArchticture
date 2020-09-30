using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MultiLayerProject.Core.Repositories;
using MultiLayerProject.Core.Services;
using MultiLayerProject.Data;
using MultiLayerProject.Data.Repositories;
using MultiLayerProject.Service.Services;

namespace MultiLayerProject
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
            services.AddDbContext<ApplicationDbContext>(option =>
        option.UseSqlServer(connectionString: Configuration.GetConnectionString("Default")));


            services.AddControllers();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClientService, ClientService>();


            services.AddSwaggerGen(option =>
            {
                #region Version1
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "V1-AspNetCoreCleanArchitecture Web API",
                    Description = "This Api will be responsible for overall data distribution and authorization.",
                    Contact = new OpenApiContact
                    {
                        Name = "Shivnath",
                        Email = "shivnath0001@gmail.com",
                        Url = new Uri("https://www.google.com"),
                    }
                });
                #endregion

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                #region Version1
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "V1-AspNetCoreCleanArchitecture Web API");
                #endregion


            });



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
