using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ChatService.Filters
{
    public class ChatException:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                if (context.Exception is DbUpdateException)
                {
                    Console.WriteLine(context.Exception.Message);
                }
            }
        }
    }
}
