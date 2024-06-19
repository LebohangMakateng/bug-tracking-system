using System.Collections.Generic;

namespace BugTrackingSystem.Models;
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; } // QA, RD, PM, Administrator

    // Navigation properties
    public ICollection<Bug> CreatedBugs { get; set; }
    public ICollection<Bug> ResolvedBugs { get; set; }
}
