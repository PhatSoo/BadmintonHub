﻿namespace BadmintonHub.Models
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
        public Guid Id { get; init; }
        public string Name { get; init; }
        public CourtType Type { get; init; }
        public CourtStatus Status { get; init; }
        public decimal PricePerHour { get; init; }
        public string Description { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        public Court()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
