using aspnet.Enitites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace aspnet.Data;

public class BugContext : DbContext
{
    public BugContext(DbContextOptions<BugContext> options) : base(options) { }

    public DbSet<Bug> Bugs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bug>()
            .Property(b => b.Summary).IsRequired();

        modelBuilder.Entity<Bug>()
            .Property(b => b.Description).IsRequired();

        // Configure relationships between models
    }
}
