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
        public DateTime StartTime { get; init; }

        [Required]
        [Range(30, 180, ErrorMessage = "You can booking at least > 30m & < 180m")]
        public int Duration { get; init; }
    }
}
