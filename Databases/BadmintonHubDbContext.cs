using BadmintonHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Databases
{
    public class BadmintonHubDbContext: DbContext
    {
        public BadmintonHubDbContext(DbContextOptions<BadmintonHubDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<FieldClosure> FieldClosures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Status).HasDefaultValue(Constants.UserStatus.Active);
            modelBuilder.Entity<Court>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Staff>().HasIndex(c => c.PIN).IsUnique();
            modelBuilder.Entity<Staff>().HasIndex(c => c.Email).IsUnique();

            modelBuilder.Entity<Booking>().HasOne(b => b.Court).WithMany(c => c.Bookings).HasForeignKey(b => b.CourtId);
            modelBuilder.Entity<Booking>().HasOne(b => b.User).WithMany(u => u.Bookings).HasForeignKey(b => b.UserId);
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Customer>().Property(c => c.IsVip).HasDefaultValue(false);

            modelBuilder.Entity<Info>().HasData(
                new Info
                {
                    Id = Guid.Parse("103dfd14-502c-49b9-84c2-888b99e1f2f4"),
                    Name = "Badminton Hub",
                    Phone = "0123456789",
                    Address = "Đại lộ Bình Dương, Thủ Dầu Một, Bình Dương",
                    Email = "abc@gmail.com",
                    Description = "Badminton Hub is your ultimate destination for badminton enthusiasts! We offer easy online court booking so you can secure your playtime hassle-free. Whether you're a beginner or a pro, you can also hire professional coaches to improve your skills and enjoy personalized training sessions. Experience top-quality facilities and expert guidance all in one place at Badminton Hub!",
                    WorkingTime = "8:00 - 22:00",
                });
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
