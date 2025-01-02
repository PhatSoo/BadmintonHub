using BadmintonHub.Models;

namespace BadmintonHub.Facades
{
    public interface IBookingCourtFacade
    {
        public Task CreateBookingAsync(Booking booking);
    }
}
