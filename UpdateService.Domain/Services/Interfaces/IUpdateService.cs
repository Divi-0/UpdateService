using System;
using System.Threading.Tasks;

namespace UpdateService.Domain.Services.Interfaces
{
    public interface IUpdateService
    {
        Task<byte[]> UpdateAsync(Version version);
    }
}
