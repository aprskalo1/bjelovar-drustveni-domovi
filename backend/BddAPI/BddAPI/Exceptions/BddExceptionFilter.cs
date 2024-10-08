using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BddAPI.Exceptions;

public class BddExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not BddCustomException bddCustomException) return;
        context.Result = context.Exception switch
        {
            BddCustomException => new BadRequestObjectResult(new
            {
                bddCustomException.Message
            }),
            _ => context.Result
        };

        context.ExceptionHandled = true;
    }
}