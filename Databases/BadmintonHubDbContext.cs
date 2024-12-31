using BadmintonHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Databases
{
    public class BadmintonHubDbContext: DbContext
    {
        public BadmintonHubDbContext(DbContextOptions<BadmintonHubDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Court> Courts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Court>().HasIndex(u => u.Name).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
