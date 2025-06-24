using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.UserDtos
{
    public record LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; init; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; init; } = null!;
    }
}
