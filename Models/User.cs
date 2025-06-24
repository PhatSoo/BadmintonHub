using System.ComponentModel.DataAnnotations;
using static BadmintonHub.Constants;

namespace BadmintonHub.Models
{


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
        public UserRole Role { get; set; }
        public UserStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Booking> Bookings { get; set; } = null!;
        public Customer? Customer { get; set; }
        public Staff? Staff { get; set; }
    }
}
