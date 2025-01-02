using BadmintonHub.Models;

namespace BadmintonHub.Dtos.CourtDtos
{
    public record CourtDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string Type { get; init; } = null!;
        public string Status { get; init; } = null!;
        public decimal PricePerHour { get; init; }
        public string? Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
