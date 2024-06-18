using System.ComponentModel.DataAnnotations;

namespace aspnet.Enitites
{
    public class Bug
    {
        public int Id { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
        public string Status { get; set; } = "Open"; // Open, In Progress, Resolved
        public string? AdditionalInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; } // Foreign key to User

        public User User { get; set; } // Navigation property for User
    }
}
