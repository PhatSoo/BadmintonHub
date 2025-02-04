using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        public bool? IsVip { get; set; }
        public string? Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User Account { get; set; } = null!;
    }
}
