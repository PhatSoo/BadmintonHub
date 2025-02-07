using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Models;
using BadmintonHub.ResponseType;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Facades
{
    public class BookingCourtFacade : IBookingCourtFacade
    {
        private readonly IUserService _userService;
        private readonly ICourtService _courtService;
        private readonly IBookingService _bookingService;
        private readonly IMomoService _momoService;

        public BookingCourtFacade(IUserService userService, ICourtService courtService, IBookingService bookingService, IMomoService momoService)
        {
            _userService = userService;
            _courtService = courtService;
            _bookingService = bookingService;
            _momoService = momoService;
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            var isExistedCourt = await _courtService.GetCourtAsync(booking.CourtId);
            if (isExistedCourt is null)
            {
                throw new KeyNotFoundException("Court not found");
            }
            var isExistedUser = await _userService.GetUserByIdAsync(booking.UserId);
            if (isExistedUser is null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _bookingService.CreateBookingAsync(booking);
        }

        public async Task<MomoPaymentResponse?> PaymentBookingAsync(Guid bookingId)
        {
            var isExistedBooking = await _bookingService.GetBookingByIdAsync(bookingId);

            if (isExistedBooking is null)
            {
                throw new KeyNotFoundException("Booking not found");
            }

            var amount = (long)((isExistedBooking.Duration / 60m) * isExistedBooking.Court.PricePerHour);

            var response = await _momoService.PaymentBookingAsync(bookingId, amount);

            return response;
        }
    }
}
