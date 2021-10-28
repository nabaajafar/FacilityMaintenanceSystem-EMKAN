
using EMKAN.API5.Installers;
using EMKAN.Application.Interfaces;
using EMKAN.Business.Servicess;
using EMKAN.DataAccess.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using EMKAN.Logging;
using EMKAN.Trace.Service;
using EMKAN.Trace.Abstraction;
using EMKAN.API5.Filter;
using Serilog;

namespace EMKAN.API5
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

            services.AddCors();
            //  services.AddControllersWithViews(options => options.Filters.Add(typeof(EmkanSessionApiFilter)));
            services.AddScoped<IUser, UserManager>();
            services.AddScoped<IService, ServicesManager>();
            services.AddScoped<IBuildingAndBranch, BuildingAndBranch>();
            services.AddScoped<IRoleAndTeam, RoleAndTeam>();
            services.AddDbContext<EMKANDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EMKANDb")));
            services.AddControllers(options => options.Filters.Add(typeof(EmkanSessionApiFilter)));
            services.AddScoped<IRequestTrace, RequestTrace>();
            services.AddHealthChecks()
             // Add a health check for a SQL Server database
             .AddCheck(
                 "DB-check",
                 new HealthCheckInstaller(Configuration.GetConnectionString("EMKANDb")),
                 HealthStatus.Unhealthy,
                 new string[] { "orderingdb" });
            services.AddHealthChecks() 
       .AddDbContextCheck<EMKANDbContext>();
            services.AddDbContext<EMKANDbContext>(options =>
            {
             options.UseSqlServer(
             Configuration["ConnectionStrings:EMKANDb"]);
            });


          
         
            services.AddHttpClient();
            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EMKAN.API5", Version = "v1" });
         
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
          
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMKAN.API5 v1"));
            }
     
           

            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod().AllowAnyHeader());


            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            //Add our new middleware to the pipeline
            app.UseMiddleware<APILoggingMiddleware>();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
               endpoints.MapHealthChecks("/health", new HealthCheckOptions()
               {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
               }
                   );

               endpoints.MapControllers();
            });
        }
    }
}
