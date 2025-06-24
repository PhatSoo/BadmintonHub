using BadmintonHub.Dtos.BookingDtos;
using BadmintonHub.Dtos.CourtDtos;
using BadmintonHub.Dtos.CustomerDto;
using BadmintonHub.Dtos.FieldDtos;
using BadmintonHub.Dtos.StaffDtos;
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
                Role = user.Role.ToString(),
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Staff = user.Staff?.AsDto(),
                Customer = user.Customer?.AsDto()
            };
        }

        public static BookingDto AsDto(this Booking booking)
        {
            return new BookingDto
            {
                Id = booking.Id,
                CourtName = booking.Court.Name,
                GuestName = booking.User?.DisplayName ?? "Unknown",
                StartTime = booking.StartTime,
                EndTime = booking.EndTime
            };
        }

        public static CustomerDto AsDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AccountId = customer.AccountId,
                IsVip = customer.IsVip,
                Address = customer.Address,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt,
            };
        }

        public static StaffDto AsDto(this Staff staff)
        {
            return new StaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Email = staff.Email,
                PhoneNumber = staff.PhoneNumber,
                PIN = staff.PIN,
                Address = staff.Address ?? "",
                CreatedAt = staff.CreatedAt,
                UpdatedAt = staff.UpdatedAt
            };
        }

        public static FieldClosure AsDto(this FieldClosure closure)
        {
            return new FieldClosure
            {
                ClosedDate = closure.ClosedDate,
                Reason = closure.Reason,
            };
        }
    }
}
