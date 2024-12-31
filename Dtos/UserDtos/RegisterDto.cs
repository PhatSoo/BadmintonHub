using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.UserDtos
{
    public record RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; init; } = null!;

        [Required]
        [MaxLength(20)]
        public string DisplayName { get; init; } = null!;

        [Required]
        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; init; } = null!;

        public UserRole Role { get; init; }
    }
}
