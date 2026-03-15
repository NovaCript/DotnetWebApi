using Microsoft.OpenApi;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services,
         ConfigurationManager configuration
         )
    {

        var stringConnection = configuration.GetConnectionString("SqliteStringConnection");

        services.AddControllers();

        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API списка контактов",
            });
        });

        services.AddCors(opt =>
        opt.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyMethod().AllowAnyHeader().WithOrigins(configuration["client"]);
        }));

        services.AddSingleton<IStorage>(new SqliteStorage(stringConnection));

        return services;
    }
}