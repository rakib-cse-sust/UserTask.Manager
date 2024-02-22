using Microsoft.EntityFrameworkCore;
using UserDetails.Api.Models.Entities;

namespace UserDetails.Api.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // Add other DbSets for related entities if needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the database schema, relationships, etc.
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Add additional configurations as needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
