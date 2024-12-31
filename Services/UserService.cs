using BadmintonHub.Databases;
using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Handlers;
using BadmintonHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class UserService : IUserService
    {
        private readonly BadmintonHubDbContext _dbContext;
        private readonly HashPasswordHandler _hashPassword;

        public UserService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
            _hashPassword = new HashPasswordHandler();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public bool LoginAysnc(User user, string enteredPassword)
        {
            bool isCorrectPassword = _hashPassword.VerifyPassword(user, enteredPassword);
            return isCorrectPassword;
        }

        public async Task RegisterAsync(RegisterDto user)
        {
            User newUser = new()
            {
                Id = Guid.NewGuid(),
                DisplayName = user.DisplayName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Password = _hashPassword.HashPassword(new User(), user.Password)
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
