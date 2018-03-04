using Microsoft.AspNetCore.Builder;

namespace BCPAO.PhotoManager.Middleware
{
    public static class InstallerExtensions
    {
        public static IApplicationBuilder UseInstaller(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InstallerMiddleware>();
        }
    }
}
