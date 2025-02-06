using BadmintonHub.Databases;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class BookingService : IBookingService
    {
        private readonly BadmintonHubDbContext _dbContext;
        public BookingService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _dbContext.Bookings.Include(c => c.Court).Include(u => u.User).ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(Guid id)
        {
            var existingBooking = await _dbContext.Bookings.Include(c => c.Court).Include(u => u.User).FirstOrDefaultAsync(b => b.Id == id);
            
            return existingBooking;
        }
    }
}
