using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.CourtDtos
{
    public record UpdateCourtDto
    {
        [Required]
        public string Name { get; init; } = null!;

        [Required]
        public CourtType Type { get; init; }

        [Required]
        public CourtStatus Status { get; init; }

        [Required]
        [Range(50000, double.MaxValue)]
        public decimal PricePerHour { get; init; }

        [Required]
        public string? Description { get; init; }
    }
}
