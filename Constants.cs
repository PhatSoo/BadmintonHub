namespace BadmintonHub
{
    public class Constants
    {
        public enum UserRole
        {
            Admin,
            Customer,
            Staff
        }

        public enum PasswordChangeResult
        {
            Success,
            InvalidOldPassword,
            UserNotFound
        }

        public enum UserStatus
        {
            Active,
            Inactive,
            Ban
        }

        public enum BookingStatus
        {
            Pending,
            Canceled,
            Completed
        }
    }
}
