using BadmintonHub.Databases;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class StaffService : IStaffService
    {
        private readonly BadmintonHubDbContext _dbContext;

        public StaffService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateStaffAsync(Staff staff)
        {
            await _dbContext.Staffs.AddAsync(staff);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Staff?> GetStaffAsync(Guid id)
        {
            return await _dbContext.Staffs.FindAsync(id);
        }

        public async Task<IEnumerable<Staff>> GetStaffsAsync()
        {
            return await _dbContext.Staffs.ToListAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            var existingStaff = await _dbContext.Staffs.FindAsync(staff.Id);
            if (existingStaff != null)
            {
                _dbContext.Entry(existingStaff).CurrentValues.SetValues(staff);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
