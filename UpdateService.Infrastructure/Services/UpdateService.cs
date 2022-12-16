using System;
using System.Threading.Tasks;
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

        public async Task<byte[]> UpdateAsync(Version version)
        {
            if (version == null || (version.Major == 0 && version.Minor == 0 && version.Build == 0))
            {
                version = new Version(1, 0, 0);
            }

            return await _updateStorage.GetVersion(version);
        }
    }
}
