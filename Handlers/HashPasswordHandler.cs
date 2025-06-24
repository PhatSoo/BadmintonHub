using BadmintonHub.Models;
using Microsoft.AspNetCore.Identity;

namespace BadmintonHub.Handlers
{
    public class HashPasswordHandler
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public HashPasswordHandler()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string enteredPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
