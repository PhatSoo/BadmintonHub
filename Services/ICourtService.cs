using BadmintonHub.Models;

namespace BadmintonHub.Services
{
    public interface ICourtService
    {
        Court GetCourt(Guid id);
        IEnumerable<Court> GetCourts();
        void CreateCourt(Court court);
        void UpdateCourt(Court court);
        void DeleteCourt(Guid id);
    }
}