using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public enum UserRole
    {
        Admin,
        User
    }

    public record User
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public string Email { get; init; } = null!;

        [Required]
        public string Password { get; init; } = null!;

        [Required]
        [StringLength(20)]
        public string DisplayName { get; init; } = null!;

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; init; } = null!;

        [Required]
        public UserRole Role { get; init; }

        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
