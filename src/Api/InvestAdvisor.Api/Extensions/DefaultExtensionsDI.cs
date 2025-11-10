namespace InvestAdvisor.Api.Extensions
{
    public static class DefaultExtensionsDI
    {
        public static IServiceCollection AddDefaultExtensions(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenApi();

            return services;
        }
    }
}