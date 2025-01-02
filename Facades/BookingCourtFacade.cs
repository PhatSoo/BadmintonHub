using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Facades
{
    public class BookingCourtFacade : IBookingCourtFacade
    {
        private readonly IUserService _userService;
        private readonly ICourtService _courtService;
        private readonly IBookingService _bookingService;

        public BookingCourtFacade(IUserService userService, ICourtService courtService, IBookingService bookingService)
        {
            _userService = userService;
            _courtService = courtService;
            _bookingService = bookingService;
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
    }
}
