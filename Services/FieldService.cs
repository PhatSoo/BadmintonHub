using BadmintonHub.Databases;
using BadmintonHub.Dtos.FieldDtos;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class FieldService : IFieldService
    {

        private readonly BadmintonHubDbContext _dbContext;
        public FieldService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCloseDate(FieldClosure data)
        {
            await _dbContext.FieldClosures.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FieldClosure>> GetCloseDates()
        {
            var today = DateTime.Today;
            var nextWeek = today.AddDays(14);

            var closedDates = await _dbContext.FieldClosures.Where(c => c.ClosedDate >= today && c.ClosedDate <= nextWeek).OrderBy(c => c.ClosedDate).ToListAsync();

            return closedDates;
        }

        public async Task UpdateClosedDate(FieldClosure data)
        {
            var existingClosure = await _dbContext.FieldClosures.FindAsync(data.Id);
            if (existingClosure != null)
            {
                _dbContext.Entry(existingClosure).CurrentValues.SetValues(data);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
