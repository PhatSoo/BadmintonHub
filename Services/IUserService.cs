using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Models;

namespace BadmintonHub.Services
{
    public interface IUserService
    {
        public Task RegisterAsync(RegisterDto user);
        public Task<User> GetUserByEmailAsync(string email);
        public Boolean LoginAysnc(User user, string enteredPassword);
    }
}
