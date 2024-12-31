using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public enum CourtType
    {
        Indoor,
        Outdoor
    }

    public enum CourtStatus
    {
        Available,
        Booked,
        Maintenance
    }

    public record Court
    {
        [Key]
        [Required]
        public Guid Id { get; init; }

        [Required]
        public string Name { get; init; } = null!;

        [Required]
        public CourtType Type { get; init; }

        [Required]
        public CourtStatus Status { get; init; }

        [Required]
        [Range(50000, Double.MaxValue)]
        public decimal PricePerHour { get; init; }

        public string? Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        public Court()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
