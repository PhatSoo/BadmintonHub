using System.ComponentModel.DataAnnotations;
using static BadmintonHub.Constants;

namespace BadmintonHub.Models
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CourtId { get; set; }
        public Guid UserId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Duration { get; set; } // Duration in minutes
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Foreign keys
        public Court Court { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
