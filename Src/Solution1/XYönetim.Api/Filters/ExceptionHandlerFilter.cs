using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using X.Yönetim.Application.Exceptions;
using X.Yönetim.Application.Wrapper;

namespace XYönetim.Api.Filters
{
    public class ExceptionHandlerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

         
          var result =new Result<dynamic>() { Success=false};

            if (context.Exception is NotFoundException notFoundException)
            {
                //var notFoundException = context.Exception as NotFoundException;
                result.Errors = new List<string> { notFoundException.Message };
            }
            else if (context.Exception is AlreadyExistsException alreadyExistsException)
            {
                result.Errors = new List<string> { alreadyExistsException.Message };
            }
            else if (context.Exception is ValidateException validationException)
            {
                result.Errors.AddRange(validationException.ErrorMessages);
            }
            else
            {
                result.Errors = new List<string> { context.Exception.InnerException != null ? context.Exception.InnerException.Message : context.Exception.Message };
            }
           
            
            Log.Error(context.Exception, $"{context.HttpContext.Request.Path} adresi çağrılırken bir hata oluştu.");

            context.Result = new JsonResult(result);
            context.HttpContext.Response.StatusCode = 400;

            context.ExceptionHandled = true;
        }
    }
}
