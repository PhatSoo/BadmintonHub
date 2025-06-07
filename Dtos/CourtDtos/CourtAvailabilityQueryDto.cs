using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.CourtDtos
{
    public class CourtAvailabilityQueryDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }
    }
}
