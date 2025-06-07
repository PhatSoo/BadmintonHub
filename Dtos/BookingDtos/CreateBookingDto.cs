using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.BookingDtos
{
    public record CreateBookingDto
    {
        [Required]
        public Guid CourtId { get; init; }

        [Required]
        public Guid UserId { get; init; }

        [Required]
        public TimeSpan StartTime { get; init; }

        [Required]
        public TimeSpan EndTime { get; init; }
    }
}
