using BadmintonHub.Models;
using Microsoft.AspNetCore.Http.Features;

namespace BadmintonHub.Services
{
    public class CourtService : ICourtService
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

        public void CreateCourt(Court court)
        {
            courts.Add(court);
        }

        public void UpdateCourt(Court court)
        {
            var idx = courts.FindIndex(existingCourt => existingCourt.Id == court.Id);
            courts[idx] = court;
        }

        public void DeleteCourt(Guid id)
        {
            var idx = courts.FindIndex(court => court.Id == id);
            courts.RemoveAt(idx);
        }
    }
}
