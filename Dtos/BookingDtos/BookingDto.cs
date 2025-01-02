namespace BadmintonHub.Dtos.BookingDtos
{
    public record BookingDto
    {
        public Guid Id { get; init; }
        public string CourtName { get; init; } = null!;
        public string GuestName { get; init; } = null!;
        public int Duration { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
    }
}
