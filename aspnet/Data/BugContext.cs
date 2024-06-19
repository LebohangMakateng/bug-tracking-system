using BugTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Data
{
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

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.CreatedBy)
                .WithMany(u => u.CreatedBugs)
                .HasForeignKey(b => b.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bug>()
                .HasOne(b => b.ResolvedBy)
                .WithMany(u => u.ResolvedBugs)
                .HasForeignKey(b => b.ResolvedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.Role).IsRequired();

            // Additional configuration for Phase II
            modelBuilder.Entity<Bug>()
                .Property(b => b.Type).IsRequired();

            modelBuilder.Entity<Bug>()
                .HasDiscriminator<string>("Type")
                .HasValue<Bug>("Bug")
                .HasValue<FeatureRequest>("FeatureRequest")
                .HasValue<TestCase>("TestCase");
        }
    }
}
