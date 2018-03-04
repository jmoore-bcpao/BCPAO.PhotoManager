using BCPAO.PhotoManager.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Middleware
{
    public class InstallerMiddleware
    {
        private readonly RequestDelegate _next;

        public InstallerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var db = context.RequestServices.GetService(typeof(DatabaseContext)) as DatabaseContext;

            if (!db.Users.Any())
            {
                if (!context.Request.Path.ToString().Contains("/Install"))
                {
                    context.Request.Path = "/Install";
                }
            }
            else
            {
                if (context.Request.Path.ToString().Contains("/Install"))
                {
                    context.Request.Path = "/";
                }
            }

            return _next(context);
        }
    }
}
