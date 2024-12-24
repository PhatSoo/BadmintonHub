using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos
{
    public record CreateCourtDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public CourtType Type { get; init; }

        [Required]
        public CourtStatus Status { get; init; }

        [Required]
        [Range(50000, Double.MaxValue)]
        public decimal PricePerHour { get; init; }

        [Required]
        public string Description { get; init; }
    }
}
