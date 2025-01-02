using BadmintonHub.Models;
using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.CourtDtos
{
    public record UpdateStatusCourtDto
    {
        [Required]
        public CourtStatus Status { get; init; }
    }
}
