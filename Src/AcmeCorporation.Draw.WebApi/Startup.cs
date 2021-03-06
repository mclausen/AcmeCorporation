﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorporation.Draw.Domain.Events;
using AcmeCorporation.Draw.Domain.Interfaces;
using AcmeCorporation.Draw.Infrastructure.Handlers;
using AcmeCorporation.Draw.Infrastructure.Services;
using AcmeCorporation.Draw.Infrastructure.Storage;
using AcmeCorporation.Draw.WebApi.Extensions;
using AcmeCorporation.Draw.WebApi.Filters;
using AcmeCorporation.Draw.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace AcmeCorporation.Draw.WebApi
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

            RegisterJwtAuthTokenConfiguration();
            RegisterDababaseConfiguration(services);

            services
                .AddMvc(options => 
                {
                    options.Filters.Add<ModelStateValidationFilter>();
                    options.Filters.Add<DomainExceptionHandlingFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            

            RegisterServices(services);

            RegisterEventHandlers(services);
        }

        

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ISerialNumberRepository, SerialNumberRespository>();
            services.AddTransient<IDrawSubmissionService, DrawSubmissionService>();
        }

        private void RegisterDababaseConfiguration(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DrawDbConnectionString");
            services
                .AddDbContext<DrawDbContext>(contextOptions =>
                {
                    contextOptions.UseSqlServer(connectionString,
                        sqloptions => sqloptions
                            .MigrationsAssembly("AcmeCorporation.Draw.Infrastructure"));
                });
        }

        private void RegisterEventHandlers(IServiceCollection services)
        {
            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IPublishDomainEvent>(collection => collection.GetService<IEventDispatcher>() as EventDispatcher);

            // Handlers
            services.AddScoped<IHandleDomainEvent<DrawSubmissionRetrievedDomainEvent>, DrawSubmissionRetrievedDomainEventHandler>();
        }

        public void RegisterJwtAuthTokenConfiguration()
        {
            /*
             Here is were i wanted to enable jwt bearer token authentication
             They i wanted to impment it was having an Identity Server issueing the access
             tokens, and then have the individual servies validating them.
           */
            //            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //                        .AddJwtBearer(options =>
            //                        {
            //                            options.TokenValidationParameters = new TokenValidationParameters
            //                            {
            //                                ValidateIssuer = true,
            //                                ValidateAudience = true,
            //                                ValidateLifetime = true,
            //                                ValidateIssuerSigningKey = true,
            //                     
            //                                ValidIssuer = "<path to identity my server>",
            //                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("<signing key>"))
            //                            };
            //                        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Should be configured for production usages
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .Build()
            );

            app.UseMiddleware<EFUnitOfWorkMiddleware>();
            
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
            
            app.MigrateDabase();

        }

    }
}
