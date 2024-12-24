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

    public class Court
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CourtType Type { get; set; }
        public CourtStatus Status { get; set; }
        public decimal PricePerHour { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Court()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
