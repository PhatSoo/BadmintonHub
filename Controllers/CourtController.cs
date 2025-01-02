using BadmintonHub.Dtos.CourtDtos;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1/courts")]
    public class CourtController : Controller
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
            var existingCourt = _courtsService.GetCourtAsync(id);
            if (existingCourt is null)
            {
                return NotFound();
            }
            Court updatedCourt = await existingCourt with
            {
                Name = court.Name,
                Type = court.Type,
                Status = court.Status,
                PricePerHour = court.PricePerHour,
                Description = court.Description,
            };
            await _courtsService.UpdateCourtAsync(updatedCourt);
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
            Court updatedCourt = existingCourt with
            {
                Status = status.Status
            };
            await _courtsService.UpdateCourtStatusAsync(updatedCourt);
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
    }
}
