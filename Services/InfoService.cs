using BadmintonHub.Databases;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class InfoService : IInfoService
    {
        private readonly BadmintonHubDbContext _dbContext;

        public InfoService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Info?> GetInfoAsync()
        {
            return await _dbContext.Infos.FirstOrDefaultAsync();
        }

        public Task UpdateInfoAsync(Info info)
        {
            throw new NotImplementedException();
        }
    }
}
