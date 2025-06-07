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
        Maintenance
    }

    public class Court
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public CourtType Type { get; set; }

        [Required]
        public CourtStatus Status { get; set; }

        [Required]
        [Range(50000, Double.MaxValue)]
        public decimal PricePerHour { get; set; }

        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Booking> Bookings { get; set; } = null!;

        //public Court()
        //{
        //    CreatedAt = DateTime.Now;
        //    UpdatedAt = DateTime.Now;
        //}
    }
}
