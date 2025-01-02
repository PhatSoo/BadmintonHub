using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Dtos.CourtDtos;
using BadmintonHub.Dtos.UserDtos;
using BadmintonHub.Models;

namespace BadmintonHub
{
    public static class Extensions
    {
        public static CourtDto AsDto(this Court court)
        {
            return new CourtDto
            {
                Id = court.Id,
                Name = court.Name,
                Type = court.Type.ToString(),
                Status = court.Status.ToString(),
                PricePerHour = court.PricePerHour,
                Description = court.Description,
                CreatedAt = court.CreatedAt,
                UpdatedAt = court.UpdatedAt
            };
        }

        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString(),
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public static BookingDto AsDto(this Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                CourtName = booking.Court.Name,
                GuestName = booking.User?.DisplayName ?? "Unknown",
                Duration = booking.Duration,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime
            };
        }
    }
}
