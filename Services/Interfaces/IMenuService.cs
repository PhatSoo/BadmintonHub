using BadmintonHub.Models;

namespace BadmintonHub.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAllMenusAsync();
        Task UpdateMenuAsync(Menu service);
    }
}
