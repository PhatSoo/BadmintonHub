using BadmintonHub.Models;

namespace BadmintonHub.Services
{
    public class CourtService
    {
        private readonly List<Court> courts = new()
        {
            new Court { Id = Guid.NewGuid(), Name = "Court 1", PricePerHour = 10, Description = "123", Type = CourtType.Indoor, Status = CourtStatus.Available },
            new Court { Id = Guid.NewGuid(), Name = "Court 2", PricePerHour = 8, Description = "123", Type = CourtType.Outdoor, Status = CourtStatus.Maintenance },
            new Court { Id = Guid.NewGuid(), Name = "Court 3", PricePerHour = 8, Description = "123", Type = CourtType.Outdoor, Status = CourtStatus.Booked }
        };

        public IEnumerable<Court> GetCourts()
        {
            return courts;
        }

        public Court GetCourt(Guid id)
        {
            return courts.SingleOrDefault(court => court.Id == id);
        }
    }
}
