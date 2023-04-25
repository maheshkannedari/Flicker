

using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatService.Filters
{
    public class ChatActions:ActionFilterAttribute
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
