using BadmintonHub.ResponseType;

namespace BadmintonHub.Services.Interfaces
{
    public interface IMomoService
    {
        public Task<MomoPaymentResponse?> PaymentBookingAsync(Guid bookingId, long amount);
    }
}
