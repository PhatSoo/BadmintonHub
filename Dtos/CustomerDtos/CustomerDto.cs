using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.CustomerDto
{
    public record CustomerDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public bool? IsVip { get; set; }
        public string? Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
