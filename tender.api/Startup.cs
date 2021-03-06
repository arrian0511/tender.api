﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Tender.Storage.Context;
using Tender.Services;
using Tender.Shared;

namespace Tender.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called when the project fires up
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">[in] Services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Cors Policy
            services.AddCors(options =>
            {
                options.AddPolicy(TenderConstants.CorsPolicyName, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                    builder.AllowCredentials();
                });
            });

            // Add framework services.
            services.AddMvc();

            // Add Db context instance
            services.AddTransient(provider =>
            {
                return new TenderContext(Configuration.GetConnectionString("(default)"));
            });

            // Add Migration context
            services.AddScoped<IMigrationService, MigrationService>();

            // Add Entity Service
            services.AddScoped<ITenderTaskManagementService, TenderTaskManagementService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">[in] Application</param>
        /// <param name="env">[in] Environment</param>
        /// <param name="loggerFactory">[in] Logger Factory Settings</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // Start database migration by using the services itself
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<IMigrationService>().StartMigration();
            }

            // Setup startup data of the application
            app
                .UseCors(TenderConstants.CorsPolicyName)
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action}/{id?}",
                        defaults: new { controller = "Home", action = "Index" });
                 });
        }
    }
}
