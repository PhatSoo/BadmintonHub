using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Services.Interfaces
{
    public interface IUserService
    {
        public Task RegisterAsync(RegisterDto user);
        public Task<User?> GetUserByEmailAsync(string email);
        public Task<User?> GetUserByIdAsync(Guid id);
        public string? LoginAysnc(User user, string enteredPassword);
        public Task<IEnumerable<User>> ListAllUsersAsync();
    }
}
