using BadmintonHub.Models;

namespace BadmintonHub.Services.Interfaces
{
    public interface ICourtService
    {
        Task<Court?> GetCourtAsync(Guid id);
        Task<IEnumerable<Court>> GetCourtsAsync(int? status);
        Task CreateCourtAsync(Court court);
        Task UpdateCourtAsync(Court court);
        Task UpdateCourtStatusAsync(Court court);
        Task DeleteCourtAsync(Guid id);
        Task<IEnumerable<Court>> GetAvailableCourts(DateTime date, TimeSpan startTime, TimeSpan endTime);
    }
}