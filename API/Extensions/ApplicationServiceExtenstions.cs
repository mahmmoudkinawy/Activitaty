namespace API.Extensions;
public static class ApplicationServiceExtenstions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
        {
            options.RequireHttpsPermanent = true;
        }).AddXmlDataContractSerializerFormatters();

        services.AddDbContext<ActivitatyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
