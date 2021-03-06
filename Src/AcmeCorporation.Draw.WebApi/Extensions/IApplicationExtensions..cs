﻿using AcmeCorporation.Draw.Infrastructure.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeCorporation.Draw.WebApi.Extensions
{
    public static class IApplicationExtensions
    {
        public static void MigrateDabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DrawDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
