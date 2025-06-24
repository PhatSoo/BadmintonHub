using System.ComponentModel.DataAnnotations;

namespace BadmintonHub.Models
{
    public class FieldClosure
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime ClosedDate { get; set; }
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
