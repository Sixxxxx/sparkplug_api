using MongoDB.Driver;
using SparkPlug.Services.Infrastructures;

namespace SchMgr.Api.Extension
{
    public static class ConfigurationBinder
    {
        public static IServiceCollection BindConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            DatabaseSettings settings = new();
            configuration.GetSection("DatabaseSettings").Bind(settings);
            services.AddSingleton(settings);
            services.AddSingleton<IMongoClient>(s => new MongoClient(settings.ConnectionString));
            return services;
        }
    }
}
