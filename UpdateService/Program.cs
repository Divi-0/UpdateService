using UpdateService.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        IConfigurationBuilder configBuilder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddEnvironmentVariables();

        IConfiguration config = configBuilder.Build();

        // Add services to the container.

        builder.Services.AddSingleton<IConfiguration>(provider => config);
        builder.Services.AddInfrastructureServices();

        builder.Services.AddControllers();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}