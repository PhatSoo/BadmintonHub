using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Facades;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("api/v1/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingCourtFacade _bookingCourtFacade;
        private readonly IBookingService _bookingService;

        public BookingController(IBookingCourtFacade bookingCourtFacade, IBookingService bookingService)
        {
            _bookingCourtFacade = bookingCourtFacade;
            _bookingService = bookingService;
        }

        // GET /bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookings()
        {
            var result = await _bookingService.GetAllBookingsAsync();
            return Ok(result.Select(item => item.AsDto()));
        }

        // GET /bookings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetBookingByIdAsync(Guid id)
        {
            var result = await _bookingService.GetBookingByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result.AsDto());
        }

        // POST /bookings
        [HttpPost]
        public async Task<ActionResult<CreateBookingDto>> CreateBookingAsync(CreateBookingDto bookingDto)
        {
            try
            {
                Booking newBooking = new()
                {
                    Id = Guid.NewGuid(),
                    CourtId = bookingDto.CourtId,
                    UserId = bookingDto.UserId,
                    Duration = bookingDto.Duration,
                    StartTime = bookingDto.StartTime
                };

                await _bookingCourtFacade.CreateBookingAsync(newBooking);
                return CreatedAtAction(nameof(GetBookings), new { Id = newBooking.Id }, newBooking.AsDto());
            } catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
           
        }
    }
}
