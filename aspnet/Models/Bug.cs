using System;
using System.ComponentModel.DataAnnotations;

namespace BugTrackingSystem.Models;
public class Bug
{
    public int Id { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public int? ResolvedById { get; set; }
    public User ResolvedBy { get; set; }
    public string Severity { get; set; }
    public string Priority { get; set; }
    public string Type { get; set; } // Bug, FeatureRequest, TestCase
}
