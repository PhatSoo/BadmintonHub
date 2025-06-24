using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.StaffDtos
{
    public record CreateStaffDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(12, MinimumLength = 12)]
        public string PIN { get; set; } = null!;

        public string? Address { get; set; } = null!;
    }
}
