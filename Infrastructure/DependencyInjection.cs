using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    //public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());
    //    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    //    services.AddScoped<IUnitOfWork, UnitOfWork>();
    //    services.AddSingleton<IErrorMessageLog, ErrorMessageLog>();
    //    services.AddScoped<IConfigurationExtension, ConfigurationExtensions>();

    //    return services;
    //}
}
