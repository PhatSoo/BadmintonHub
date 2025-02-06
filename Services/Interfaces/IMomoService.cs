namespace BadmintonHub.Services.Interfaces
{
    public interface IMomoService
    {
        public Task<string?> PaymentBookingAsync(Guid bookingId, long amount);
    }
}
