using System.Diagnostics;

namespace ShoppingCart.Models.Middleware
{
    public class LoginStatusCheck
    {
        private RequestDelegate next;

        public LoginStatusCheck(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Debug.WriteLine(context.Request.Path);
            if (context.Request.Path == "/login/" || context.Request.Path == "/Login/Login")
            {
                await next(context);
                return;
            }
            string? sessionId = (string?)context.Request.Cookies["sessionId"];
            if (sessionId == null)
            {
                context.Response.Redirect("/login/");
            }
            else
            {
                await next(context);
            }
        }
    }
}
