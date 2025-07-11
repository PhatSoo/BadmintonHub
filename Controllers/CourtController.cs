﻿using BadmintonHub.Dtos.CourtDtos;
using BadmintonHub.Models;
using BadmintonHub.Services;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1/courts")]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtsService;

        public CourtController(ICourtService courtService)
        {
            _courtsService = courtService;
        }

        // GET /courts
        [HttpGet]
        public async Task<IEnumerable<CourtDto>> GetCourtsAsync([FromQuery] int? status)
        {
            var courts = (await _courtsService.GetCourtsAsync(status)).Select(court => court.AsDto());
            return courts;
        }

        // GET /courts/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CourtDto>> GetCourtAsync(Guid id)
        {
            var court = await _courtsService.GetCourtAsync(id);
            if (court is null)
            {
                return NotFound();
            }
            return Ok(court.AsDto());
        }

        // POST /courts
        [HttpPost]
        public async Task<ActionResult<CourtDto>> CreateCourtAsync(CreateCourtDto court) {
            Court newCourt = new()
            {
                Id = Guid.NewGuid(),
                Name = court.Name,
                Type = court.Type,
                Status = court.Status,
                PricePerHour = court.PricePerHour,
                Description = court.Description,
            };

            await _courtsService.CreateCourtAsync(newCourt);

            return CreatedAtAction(nameof(GetCourtAsync), new { id = newCourt.Id }, newCourt.AsDto());
        }

        // PUT /courts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourtAsync(Guid id, UpdateCourtDto court)
        {
            var existingCourt = await _courtsService.GetCourtAsync(id);
            if (existingCourt is null)
            {
                return NotFound();
            }
            existingCourt.Name = court.Name;
            existingCourt.Type = court.Type;
            existingCourt.Status = court.Status;
            existingCourt.PricePerHour = court.PricePerHour;
            existingCourt.Description = court.Description;
            await _courtsService.UpdateCourtAsync(existingCourt);
            return NoContent();
        }

        // PATCH /courts/{id}/status
        [HttpPatch("{id}/status")]
        public async Task<ActionResult> UpdateCourtStatusAsync(Guid id, UpdateStatusCourtDto status)
        {
            if (!Enum.IsDefined(typeof(CourtStatus), status.Status)) // Undifined Status Found
            {
                return BadRequest();
            }
            var existingCourt = await _courtsService.GetCourtAsync(id);
            if (existingCourt is null)
            {
                return NotFound();
            }
            existingCourt.Status = status.Status;
            await _courtsService.UpdateCourtStatusAsync(existingCourt);
            return NoContent();
        }

        // DELETE /courts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCourtAsync(Guid id)
        {
            var existingCourt = _courtsService.GetCourtAsync(id);
            if (existingCourt is null)
            {
                return NotFound();
            }
            _courtsService.DeleteCourtAsync(id);
            return NoContent();
        }

        // GET /courts/available-courts
        [HttpGet("available-courts")]
        public async Task<ActionResult<IEnumerable<CourtDto>>> GetAvailableCourtsAsync([FromQuery] CourtAvailabilityQueryDto query)
        {
            var availableCourts = await _courtsService.GetAvailableCourts(query.Date, query.StartTime, query.EndTime);
            if (availableCourts is null || !availableCourts.Any())
            {
                return NotFound("No available courts found for the specified time.");
            }
            return Ok(availableCourts.Select(court => court.AsDto()));
        }
    }
}
