using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HM4_M6.Filter
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            
            context.Result = new ContentResult
            {
                Content = $"You can't delete, you should be authorization"
            };
            context.ExceptionHandled = true;
        }
    }
}
