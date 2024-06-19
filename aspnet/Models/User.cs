namespace BugTrackingSystem.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } // Hash password in production
    public string UserType { get; set; } // QA, RD
}


