using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace ApiGateway.Mobile.Module.RateLimiting;

/// <summary>
/// RateLimiting Extensions
/// </summary>
public static class RateLimitingExtensions
{

    /// <summary>
    /// Agregar Rate limiting al program
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddRateLimitingPolicy(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter("customPolicy", opt =>
            {
                opt.PermitLimit = 2;
                opt.Window = TimeSpan.FromSeconds(10);
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 20;
            });
        });

        return services;
    }

    /// <summary>
    /// Usar Rate Limiting en el program
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseRateLimitingPolicy(this IApplicationBuilder app)
    {
        app.UseRateLimiter();

        return app;
    }

}
