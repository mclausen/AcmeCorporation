using AcmeCorporation.Draw.Domain;
using AcmeCorporation.Draw.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AcmeCorporation.Draw.WebApi.Filters
{
    public class DomainExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception != null && context.Exception.GetType() == typeof(DomainException))
            {
                var domainException = context.Exception as DomainException;
                context.Result = new BadRequestObjectResult(new DomainErrorDto()
                {
                    IsDomainError = true,
                    Message = domainException.Message
                });

                context.ExceptionHandled = true;
            }
        }
    }
}
