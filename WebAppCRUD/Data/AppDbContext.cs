using WebAppCRUD.Models;
using Microsoft.EntityFrameworkCore;
namespace WebAppCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}