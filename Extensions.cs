using BadmintonHub.Dtos;
using BadmintonHub.Models;

namespace BadmintonHub
{
    public static class Extensions
    {
        public static CourtDto AsDto(this Court court)
        {
            return new CourtDto
            {
                Id = court.Id,
                Name = court.Name,
                Type = court.Type,
                Status = court.Status,
                PricePerHour = court.PricePerHour,
                Description = court.Description,
                CreatedAt = court.CreatedAt,
                UpdatedAt = court.UpdatedAt
            };
        }
    }
}
