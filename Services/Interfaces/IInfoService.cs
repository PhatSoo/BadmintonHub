using BadmintonHub.Models;

namespace BadmintonHub.Services.Interfaces
{
    public interface IInfoService
    {
        public Task<Info?> GetInfoAsync();
        public Task UpdateInfoAsync(Info info);
    }
}
