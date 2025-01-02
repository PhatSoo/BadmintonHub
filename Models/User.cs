using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public enum UserRole
    {
        Admin,
        User
    }

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string DisplayName { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Booking> Bookings { get; set; } = null!;
    }
}
