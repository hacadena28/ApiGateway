using ApiGateway.Mobile.Module.Cors;
using ApiGateway.Mobile.Module.Feature;
using ApiGateway.Mobile.Module.RateLimiting;
using ApiGateway.Mobile.Module.Swagger;
using ApiGateway.Mobile.Module.Yarp;

namespace ApiGateway.Mobile
{
    /// <summary>
    /// Startup
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Add infrastructure en el program
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddFeature()
                .AddYarpContiguration(configuration)
                .AddRateLimitingPolicy()
                .AddCorsPolicy(configuration)
                .AddSwagger();
            return services;
        }

        /// <summary>
        /// usar insfrastructure en el program
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="env"></param>
        /// <param name="config"></param>
        public static void UseInfrastructure(this IApplicationBuilder builder, IWebHostEnvironment env, IConfigurationBuilder config)
        {
            builder
                .UseRouting()
                .UseRateLimitingPolicy()
                .UseCorsPolicy()
                .UseFeature(env, config)
                .UseYarp()
                .UseSwagger(env)
                .UseAuthorization();
        }
    }
}