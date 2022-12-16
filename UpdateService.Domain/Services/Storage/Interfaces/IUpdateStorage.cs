using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace UpdateService.Domain.Services.Storage.Interfaces
{
    public interface IUpdateStorage
    {
        Task<List<Version>> GetAllAvailableVersions();
        Task<NewVersion> GetVersion(Version version);
    }
}
