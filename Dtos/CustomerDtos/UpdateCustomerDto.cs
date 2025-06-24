using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Dtos.CustomerDto
{
    public record UpdateCustomerDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public bool IsVip { get; set; }

        [Required]
        public string Address { get; set; } = null!;
    }
}
