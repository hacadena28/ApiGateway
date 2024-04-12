namespace ApiGateway.Mobile.Module.Yarp
{
    /// <summary>
    /// Yarp extension
    /// </summary>
    public static class YarpExtension
    {
        /// <summary>
        /// Agregar yarp en el program
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddYarpContiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"));

            return services;
        }

        /// <summary>
        /// Usar yarp en el program
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseYarp(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy(reverseProxyPipeline =>
                {
                        reverseProxyPipeline.UseLoadBalancing();
                });
            });
            return app;
        }
    }
}
