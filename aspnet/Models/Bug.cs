using System;
using System.Collections.Generic;

namespace BugTrackingSystem.Models
{
    public class Bug
    {
        public int BugId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public int? ResolvedById { get; set; }
        public User ResolvedBy { get; set; }
        public string Severity { get; set; }
        public string Priority { get; set; }
    }
}
