using Microsoft.AspNetCore.Mvc.Filters;

namespace Student_Management_System.Filters
{
    public class LogActionFilter :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            Console.WriteLine($"Before: {context.ActionDescriptor.DisplayName}");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"After: {context.Result}");
        }
    }
}
