using Microsoft.Extensions.DependencyInjection;
using UpdateService.Domain.Services.Interfaces;
using UpdateService.Domain.Services.Storage.Interfaces;
using UpdateService.Infrastructure.Services.Storage;

namespace UpdateService.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUpdateService, Services.UpdateService>();
            services.AddSingleton<IUpdateStorage, FileSystemUpdateStorage>();
        }
    }
}
