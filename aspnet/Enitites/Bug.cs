namespace aspnet.Enitites
{
    public class Bug
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string? AdditionalInfo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Status { get; set; } // Open, In Progress, Resolved
        public int? UserId { get; set; } // Foreign key to User

        public User User { get; set; } // Navigation property for User
    }
}
