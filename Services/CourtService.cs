using BadmintonHub.Databases;
using BadmintonHub.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class CourtService : ICourtService
    {
        private readonly BadmintonHubDbContext _dbContext;
        public CourtService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Court>> GetCourtsAsync()
        {
            return await _dbContext.Courts.ToListAsync();
        }

        public async Task<Court?> GetCourtAsync(Guid id)
        {
            return await _dbContext.Courts.FindAsync(id);
        }

        public async Task CreateCourtAsync(Court court)
        {
            await _dbContext.Courts.AddAsync(court);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCourtAsync(Court court)
        {
            var existingCourt = await _dbContext.Courts.FindAsync(court.Id);
            if (existingCourt != null)
            {
                _dbContext.Entry(existingCourt).CurrentValues.SetValues(court);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateCourtStatusAsync(Court court)
        {
            var existingCourt = await _dbContext.Courts.FindAsync(court.Id);
            if (existingCourt is not null)
            {
                _dbContext.Entry(existingCourt).CurrentValues.SetValues(court);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteCourtAsync(Guid id)
        {
            var court = await _dbContext.Courts.FindAsync(id);
            if (court is not null)
            {
                _dbContext.Courts.Remove(court);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
