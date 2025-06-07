using BadmintonHub.Dtos.FieldDtos;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("api/v1/field")]
    public class FieldController : ControllerBase
    {
        private readonly IFieldService _fieldService;

        public FieldController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        // GET /closed_dates
        [HttpGet("closed_dates")]
        public async Task<ActionResult<List<FieldClosure>>> GetCloseDates()
        {
            var closedDates = await _fieldService.GetCloseDates();
            return Ok(closedDates);
        }

        [HttpPost("closed_dates")]
        public async Task<ActionResult> AddCloseDate(CreateCloseDateDto data)
        {
            try
            {
                FieldClosure fieldClosure = new()
                {
                    Id = Guid.NewGuid(),
                    ClosedDate = data.ClosedDate,
                    Reason = data.Reason
                };

                await _fieldService.AddCloseDate(fieldClosure);
                return CreatedAtAction(nameof(GetCloseDates), new { id = fieldClosure.Id }, fieldClosure.AsDto());
            }
            catch (Exception e)
            {
                // Log the exception (not implemented here)
                throw new BadHttpRequestException("An error occurred while adding the close date.", 500, e);
            }
        }

        [HttpPatch("closed_dates/{id}")]
        public async Task<ActionResult<FieldClosure>> UpdateClosedDate(Guid id, UpdateCloseDateDto data)
        {
            var closedDate = await _fieldService.GetCloseDates();
            var existingClosure = closedDate.FirstOrDefault(c => c.Id == id);
            if (existingClosure == null)
            {
                return NotFound();
            }
            existingClosure.Reason = data.Reason;

            await _fieldService.UpdateClosedDate(existingClosure);

            return NoContent();
        }
    }
}
