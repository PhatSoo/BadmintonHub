using BadmintonHub.Databases;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class MenuService : IMenuService
    {
        private readonly BadmintonHubDbContext _dbContext;
        public MenuService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Menu>> GetAllMenusAsync()
        {
            return await _dbContext.Menu.ToListAsync();
        }
        public Task UpdateMenuAsync(Menu service)
        {
            throw new NotImplementedException();
        }

    }
}
