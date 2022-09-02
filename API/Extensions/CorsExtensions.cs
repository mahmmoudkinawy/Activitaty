namespace API.Extensions;
public static class CorsExtensions
{
    public static IServiceCollection AddConfigureCors(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configurtion = serviceProvider.GetRequiredService<IConfiguration>();

        var originsAllowed = configurtion.GetSection(CorsConstants.CorsOriginSectionKey)
            .GetChildren()
            .Select(c => c.Value)
            .ToArray();

        if (!originsAllowed.Any()) return services;

        services.AddCors(options =>
        {
            options.AddPolicy(CorsConstants.CorsPolicyName, policy =>
            {
                policy
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins(originsAllowed);
            });
        });

        return services;
    }
}
