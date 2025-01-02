using BadmintonHub.Databases;
using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Handlers;
using BadmintonHub.Mappings;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BadmintonHub.Services
{
    public class UserService : IUserService
    {
        private readonly BadmintonHubDbContext _dbContext;
        private readonly HashPasswordHandler _hashPassword;
        private readonly GenerateJwtTokenHandler _generateJwtToken;

        public UserService(BadmintonHubDbContext dbContext, IOptionsMonitor<JwtMapping> optionMonitor)
        {
            _dbContext = dbContext;
            _hashPassword = new HashPasswordHandler();
            _generateJwtToken = new GenerateJwtTokenHandler(optionMonitor);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> ListAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id) ?? null;
        }

        public string? LoginAysnc(User user, string enteredPassword)
        {
            bool isCorrectPassword = _hashPassword.VerifyPassword(user, enteredPassword);
            if (!isCorrectPassword)
            {
                return null;
            }

            string token = _generateJwtToken.GenerateJwtToken(user);

            return token;
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
