using EMKAN.API5.Installers;
using EMKAN.DataAccess.DbContexts;
using EMKAN.Logging;
using EMKAN.PresentationLayer_Back_Office_.Filter;
using EMKAN.PresentationLayer_Back_Office_.Interfaces;
using EMKAN.PresentationLayer_Back_Office_.Models;
using EMKAN.Trace.Abstraction;
using EMKAN.Trace.Service;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMKAN.PresentationLayer_Back_Office_
{
    public class Startup
    {
        public static string BaseUrl { get; private set; }
        public static string BaseMvcUrl { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            BaseUrl = Configuration.GetSection("BaseUrl").Value;
            BaseMvcUrl = Configuration.GetSection("BaseMvcUrl").Value;
        }
        public static string GetBaseUrl()
        {
            return Startup.BaseUrl;
        }
        public static string GetMvcBaseUrl()
        {
            return Startup.BaseMvcUrl;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();


           


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(double.Parse(Configuration["SessionTimeOutInterval"]));
 
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews(options => options.Filters.Add(typeof(EmkanSessionFilter)));
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IRequestTrace, RequestTrace>();
          
            services.AddHealthChecks()
    .AddCheck("Back office MVC", () =>
        HealthCheckResult.Healthy("Back office MVC is OK!"), tags: new[] { "Back office MVC " });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
           
            services
                         .AddControllersWithViews()
                         .AddJsonOptions(options =>
                             options.JsonSerializerOptions.PropertyNamingPolicy = null);

      
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
                app.UseExceptionHandler("/Account/Error");
            }
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == 403)
                {
                    context.HttpContext.Response.Redirect("/Account/Error");
                }
                if (context.HttpContext.Response.StatusCode == 401)
                {
                    context.HttpContext.Response.Redirect("/Account/LoginView");
                }
            }
            );

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
           

            app.UseHsts();
            app.UseSerilogRequestLogging();
            app.UseMiddleware<MVCLoggingMiddleware>();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next();
            });

            app.UseRouting();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }
                  );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=LoginView}/{id?}");
            });
        }
    }
}
