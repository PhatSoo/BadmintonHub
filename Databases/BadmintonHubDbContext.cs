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
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Court>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Booking>().HasOne(b => b.Court).WithMany(c => c.Bookings).HasForeignKey(b => b.CourtId).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            DateTime currentDate = DateTime.Now;
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = currentDate;
                }
                entry.Property("UpdatedAt").CurrentValue = currentDate;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
