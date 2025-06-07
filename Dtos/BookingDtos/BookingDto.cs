namespace BadmintonHub.Dtos.BookingDtos
{
    public record BookingDto
    {
        public Guid Id { get; init; }
        public string CourtName { get; init; } = null!;
        public string GuestName { get; init; } = null!;
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
    }
}
