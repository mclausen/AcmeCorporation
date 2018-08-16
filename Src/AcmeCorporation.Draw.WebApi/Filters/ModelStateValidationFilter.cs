using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AcmeCorporation.Raffle.WebApi.Filters
{
    public class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           if(context.ModelState.IsValid == false)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}