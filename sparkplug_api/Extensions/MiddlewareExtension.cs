using SparkPlug.Services.Implementation;
using SparkPlug.Services.Interfaces;

namespace SparkPlug.Api.Extensions
{
    public static class MiddlewareExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IFormService, FormService>();            
        }
    }
}
