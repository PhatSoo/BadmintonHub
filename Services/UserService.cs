using BadmintonHub.Databases;
using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Handlers;
using BadmintonHub.Mappings;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using static BadmintonHub.Constants;

namespace BadmintonHub.Services
{
    public class UserService : IUserService
    {
        private readonly BadmintonHubDbContext _dbContext;
        private readonly HashPasswordHandler _hashPassword;
        private readonly GenerateJwtTokenHandler _generateJwtToken;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(BadmintonHubDbContext dbContext, IOptionsMonitor<JwtMapping> optionMonitor, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _hashPassword = new HashPasswordHandler();
            _generateJwtToken = new GenerateJwtTokenHandler(optionMonitor);
            _httpContextAccessor = httpContextAccessor;
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
            return await _dbContext.Users.Include(u => u.Customer).Include(u => u.Staff).FirstOrDefaultAsync(u => u.Id == id);
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
                Role = user.Role,
                Password = _hashPassword.HashPassword(new User(), user.Password)
            };

            if (newUser.Role == UserRole.Customer)
            {
                newUser.Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    AccountId = newUser.Id,
                    Email = newUser.Email,
                    Name = newUser.DisplayName,
                    PhoneNumber = user.PhoneNumber
                };
            } else
            {
                newUser.Staff = new Staff
                {
                    Id = Guid.NewGuid(),
                    AccountId = newUser.Id,
                    Email = newUser.Email,
                    Name = newUser.DisplayName,
                    PhoneNumber = user.PhoneNumber,
                    PIN = user.PIN
                };
            }

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public Guid? GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(userId, out var guid) ? guid : null;
        }

        public async Task<PasswordChangeResult> ChangePasswordAsync(Guid? userId, string oldPass, string newPass)
        {
            var existingUser = await _dbContext.Users.FindAsync(userId);
            
            if (existingUser is null)
            {
                return PasswordChangeResult.UserNotFound;                
            }
            bool isCorrectPassword = _hashPassword.VerifyPassword(existingUser, oldPass);
            if (!isCorrectPassword)
            {
                return PasswordChangeResult.InvalidOldPassword;
            }

            existingUser.Password = _hashPassword.HashPassword(new User(), newPass);
            await _dbContext.SaveChangesAsync();

            return PasswordChangeResult.Success;
        }
    }
}
