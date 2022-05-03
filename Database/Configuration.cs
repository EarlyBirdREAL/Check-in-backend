using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public class Configuration
{
    public static IServiceCollection AddDataAccess(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        return services;
    }

    private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var databaseConfig = configuration.GetSection("DbVariables").Get< DbConfig>();
    }

}