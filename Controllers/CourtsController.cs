using BadmintonHub.Dtos;
using BadmintonHub.Models;
using BadmintonHub.Services;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/courts")]
    public class CourtsController : Controller
    {
        private readonly ICourtService _courtsService;

        public CourtsController(ICourtService _courtService)
        {
            this._courtsService = _courtService;
        }

        // GET /courts
        [HttpGet]
        public IEnumerable<CourtDto> GetCourts()
        {
            var courts = _courtsService.GetCourts().Select(court => court.AsDto());
            return courts;
        }

        // GET /courts/{id}
        [HttpGet("{id}")]
        public ActionResult<CourtDto> GetCourt(Guid id)
        {
            var court = _courtsService.GetCourt(id);
            if (court is null)
            {
                return NotFound();
            }
            return Ok(court.AsDto());
        }

        // POST /courts
        [HttpPost]
        public ActionResult<CourtDto> CreateCourt(CreateCourtDto court) {
            Court newCourt = new()
            {
                Id = Guid.NewGuid(),
                Name = court.Name,
                Type = court.Type,
                Status = court.Status,
                PricePerHour = court.PricePerHour,
                Description = court.Description,
            };

            _courtsService.CreateCourt(newCourt);

            return CreatedAtAction(nameof(GetCourt), new { id = newCourt.Id }, newCourt.AsDto());
        }

        // PUT /courts/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCourt(Guid id, UpdateCourtDto court)
        {
            var existingCourt = _courtsService.GetCourt(id);
            if (existingCourt is null)
            {
                return NotFound();
            }
            Court updatedCourt = existingCourt with
            {
                Name = court.Name,
                Type = court.Type,
                Status = court.Status,
                PricePerHour = court.PricePerHour,
                Description = court.Description,
            };
            _courtsService.UpdateCourt(updatedCourt);
            return NoContent();
        }

        // DELETE /courts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCourt(Guid id)
        {
            var existingCourt = _courtsService.GetCourt(id);
            if (existingCourt is null)
            {
                return NotFound();
            }
            _courtsService.DeleteCourt(id);
            return NoContent();
        }
    }
}
