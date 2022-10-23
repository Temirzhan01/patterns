using Microsoft.EntityFrameworkCore;

namespace Project_practice.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cardjson> Cardjsons { get; set; }
        public ApplicationContext() :base() { Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B3ADH4H\SQLEXPRESS;Database=appbd;Trusted_Connection=True;");
        }
    }
}
