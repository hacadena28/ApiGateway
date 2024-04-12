namespace ApiGateway.Mobile.Module.Cors;

/// <summary>
/// Extension de los cors
/// </summary>
public static class CorsExtensions
{
    private const string CorsPolicy = nameof(CorsPolicy);

    /// <summary>
    /// Agregar Cors al program
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
    {
        var corsSettings = config.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
        services.AddCors(options =>
        {
            if (corsSettings?.Origins != null)
            {
                foreach (var originSettings in corsSettings.Origins)
                {
                    options.AddPolicy(originSettings.CorsPolicy!, policy =>
                    {
                        policy.AllowAnyHeader()
                            .WithOrigins(originSettings.Origin!)
                            .WithMethods(originSettings.AllowedMethods?.ToArray() ?? Array.Empty<string>());
                    });
                }
            }
        });

        return services;
    }

    /// <summary>
    /// Use Cors en el program
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app) =>
        app.UseCors();
}