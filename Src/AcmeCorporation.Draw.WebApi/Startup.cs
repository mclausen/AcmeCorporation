using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorporation.Raffle.Domain.Interfaces;
using AcmeCorporation.Raffle.Infrastructure.Services;
using AcmeCorporation.Raffle.Infrastructure.Storage;
using AcmeCorporation.Raffle.WebApi.Extensions;
using AcmeCorporation.Raffle.WebApi.Filters;
using AcmeCorporation.Raffle.WebApi.Middleware;
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

namespace AcmeCorporation.Raffle.WebApi
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
        
            
            services
                .AddMvc(options => { options.Filters.Add<ModelStateValidationFilter>(); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration.GetConnectionString("DrawDbConnectionString");
            services
                .AddDbContext<DrawDbContext>(contextOptions =>
                {
                    contextOptions.UseSqlServer(connectionString,
                        sqloptions => sqloptions
                            .MigrationsAssembly("AcmeCorporation.Raffle.Infrastructure"));
                });


            services.AddTransient<ISerialNumberRepository, SerialNumberRespository>();
            services.AddTransient<IDrawSubmissionService, DrawSubmissionService>();
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
                app.UseDeveloperExceptionPage();
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
