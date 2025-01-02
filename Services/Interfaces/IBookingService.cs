using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Models;

namespace BadmintonHub.Services.Interfaces
{
    public interface IBookingService
    {
        public Task<IEnumerable<Booking>> GetAllBookingsAsync();
        public Task CreateBookingAsync(Booking bookingDto);
        public Task<Booking?> GetBookingByIdAsync(Guid id);
    }
}
