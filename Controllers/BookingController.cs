﻿using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Dtos.CourtDtos;
using BadmintonHub.Facades;
using BadmintonHub.Models;
using BadmintonHub.ResponseType;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;

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
                    StartTime = bookingDto.StartTime,
                    EndTime = bookingDto.EndTime,
                    Status = Constants.BookingStatus.Pending
                };

                await _bookingCourtFacade.CreateBookingAsync(newBooking);
                return CreatedAtAction(nameof(GetBookings), new { Id = newBooking.Id }, newBooking.AsDto());
            } catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST /payment/{id}
        [HttpPost("payment/{bookingId}")]
        public async Task<ActionResult> PaymentBookingAsync([FromRoute] Guid bookingId)
        {
            MomoPaymentResponse? response = await _bookingCourtFacade.PaymentBookingAsync(bookingId);
            if (response is null)
            {
                return BadRequest("Something went wrong!");
            }

            if (response.ResultCode != 0)
            {
                return BadRequest(response.Message);
            }

            return Ok(new {data = response});
        }
    }
}
