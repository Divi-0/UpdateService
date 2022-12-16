using System;
using System.Threading.Tasks;
using UpdateService.Domain;
using UpdateService.Domain.Services.Interfaces;
using UpdateService.Domain.Services.Storage.Interfaces;

namespace UpdateService.Infrastructure.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IUpdateStorage _updateStorage;

        public UpdateService(IUpdateStorage updateStorage)
        {
            _updateStorage = updateStorage;
        }

        public async Task<NewVersion> UpdateAsync(Version version)
        {
            return await _updateStorage.GetVersion(version);
        }
    }
}
