using UpdateService.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        IConfigurationBuilder configBuilder = new ConfigurationBuilder()
        .AddEnvironmentVariables();

        // Add services to the container.

        builder.Services.AddSingleton<IConfiguration>(provider => configBuilder.Build());
        builder.Services.AddInfrastructureServices();

        builder.Services.AddControllers();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}