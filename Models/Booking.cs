using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CourtId { get; set; }
        public Guid UserId { get; set; }
        public int Duration { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign keys
        public Court Court { get; set; } = null!;
        public User User { get; set; } = null!;

        public DateTime EndTime => StartTime.AddMinutes(Duration);
    }
}
