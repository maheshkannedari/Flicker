using Microsoft.AspNetCore.Mvc.Filters;

namespace PostService.Filters
{
    public class PostActions:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }


    }
}
