using BadmintonHub.Databases;
using BadmintonHub.Models;

namespace BadmintonHub.Services.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetStaffsAsync();
        Task<Staff?> GetStaffAsync(Guid id);
        Task CreateStaffAsync(Staff Staff);
        Task UpdateStaffAsync(Staff Staff);
    }
}
