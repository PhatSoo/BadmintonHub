using BadmintonHub.Dtos.StaffDtos;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("api/v1/staffs")]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        { 
            _staffService = staffService;
        }

        // GET /staffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDto>>> GetStaffsAsync()
        {
            var results = await _staffService.GetStaffsAsync();
            return Ok(results.Select(c => c.AsDto()));
        }

        // GET /staffs/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffDto>> GetStaffAsync(Guid id)
        {
            var Staff = await _staffService.GetStaffAsync(id);
            if (Staff is null)
            {
                return NotFound();
            }
            return Ok(Staff.AsDto());
        }

        // POST /staffs
        [HttpPost]
        public async Task<ActionResult<StaffDto>> CreateStaffAsync([FromBody] CreateStaffDto StaffDto)
        {
            var newStaff = new Staff
            {
                Name = StaffDto.Name,
                Email = StaffDto.Email,
                PhoneNumber = StaffDto.PhoneNumber,
                Address = StaffDto.Address,
                PIN = StaffDto.PIN
            };

            await _staffService.CreateStaffAsync(newStaff);

            return CreatedAtAction(nameof(GetStaffAsync), new { id = newStaff.Id }, newStaff.AsDto());
        }

        // PUT /staffs/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStaffAsync(Guid id, [FromBody] UpdateStaffDto StaffDto)
        {
            var existingStaff = await _staffService.GetStaffAsync(id);
            if (existingStaff is null)
            {
                return NotFound();
            }

            existingStaff.Name = StaffDto.Name;
            existingStaff.Email = StaffDto.Email;
            existingStaff.PhoneNumber = StaffDto.PhoneNumber;
            existingStaff.PIN = StaffDto.PIN;
            existingStaff.Address = StaffDto.Address;

            await _staffService.UpdateStaffAsync(existingStaff);
            return NoContent();
        }
    }
}
