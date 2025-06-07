using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public class Info
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string WorkingTime { get; set; } = string.Empty;
    }
}
