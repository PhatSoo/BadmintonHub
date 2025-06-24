using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.StaffDtos
{
    public record StaffDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string PIN { get; set; } = null!;

        public string? Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
