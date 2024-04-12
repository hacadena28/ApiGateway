namespace ApiGateway.Mobile.Module.Feature;

/// <summary>
/// Feature extension
/// </summary>
public static class FeatureExtension
{
    /// <summary>
    /// Agregar freature al program
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddFeature(this IServiceCollection services)
    {
        services.AddControllers();
        return services;
    }

    /// <summary>
    /// Usar feature en el program
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseFeature(this IApplicationBuilder app, IWebHostEnvironment env,
        IConfigurationBuilder configuration)
    {
        if (!env.IsProduction())
        {
            configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
        }

        return app;
    }
}