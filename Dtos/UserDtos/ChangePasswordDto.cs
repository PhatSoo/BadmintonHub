using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.UserDtos
{
    public record ChangePasswordDto
    {
        [Required]
        [MinLength(6)]
        public string OldPassword { get; init; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; init; } = null!;

        [Required]
        [Compare("Password")]
        public string ConfirmedPassword { get; init; } = null!;
    }
}
