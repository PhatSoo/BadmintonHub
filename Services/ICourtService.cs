using BadmintonHub.Models;

namespace BadmintonHub.Services
{
    public interface ICourtService
    {
        Task<Court> GetCourtAsync(Guid id);
        Task<IEnumerable<Court>> GetCourtsAsync();
        Task CreateCourtAsync(Court court);
        Task UpdateCourtAsync(Court court);
        Task UpdateCourtStatusAsync(Court court);
        Task DeleteCourtAsync(Guid id);
    }
}