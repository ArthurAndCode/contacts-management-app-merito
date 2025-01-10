using Microsoft.EntityFrameworkCore;
using WebAppCRUD.Models;

namespace WebAppCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Contacts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Contact>()
                .HasDiscriminator<string>("ContactType")
                .HasValue<Contact>("Contact")
                .HasValue<BusinessContact>("BusinessContact");

            base.OnModelCreating(modelBuilder);
        }
    }
}