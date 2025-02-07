using BadmintonHub.Models;
using BadmintonHub.ResponseType;

namespace BadmintonHub.Facades
{
    public interface IBookingCourtFacade
    {
        public Task CreateBookingAsync(Booking booking);
        public Task<MomoPaymentResponse?> PaymentBookingAsync(Guid bookingId);
    }
}
