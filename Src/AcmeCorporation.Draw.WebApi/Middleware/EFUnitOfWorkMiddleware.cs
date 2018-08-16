using System;
using System.Threading.Tasks;
using AcmeCorporation.Draw.Domain.Events;
using AcmeCorporation.Draw.Infrastructure.Storage;
using Microsoft.AspNetCore.Http;

namespace AcmeCorporation.Draw.WebApi.Middleware
{
    public class EFUnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;

        public EFUnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var session = context.RequestServices.GetService(typeof(DrawDbContext));
            if(session == null)
                throw new InvalidOperationException("Could not retrieve current session");
            
            await _next(context);

            var dbContext = session as DrawDbContext;
            await dbContext.SaveChangesAsync();


            var eventDispacher = context.RequestServices.GetService(typeof(IEventDispatcher));
            if (eventDispacher == null)
                throw new InvalidOperationException("Could not retrieve event dispacher");

            var typedDispatcher = eventDispacher as IEventDispatcher;
            await typedDispatcher.DispatchEvents();
        }
    }
}