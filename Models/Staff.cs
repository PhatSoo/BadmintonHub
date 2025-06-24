using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public class Staff
    {
        public Guid Id { get; set; }
        public Guid? AccountId { get; set; }
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        [StringLength(12, MinimumLength = 12)]
        public string PIN { get; set; } = null!;

        public string? Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign Key
        public User? Account { get; set; }
    }
}
