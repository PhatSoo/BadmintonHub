using BadmintonHub.Models;

namespace BadmintonHub.Dtos.UserDtos
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string Email { get; init; } = null!;
        public string DisplayName { get; init; } = null!;
        public string PhoneNumber { get; init; } = null!;
        public UserRole Role { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}
