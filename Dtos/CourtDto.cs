using BadmintonHub.Models;

namespace BadmintonHub.Dtos
{
    public record CourtDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public CourtType Type { get; init; }
        public CourtStatus Status { get; init; }
        public decimal PricePerHour { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
