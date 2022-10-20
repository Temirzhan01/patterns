using Microsoft.EntityFrameworkCore;

namespace Project_practice.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cardjson> Cardjsons { get; set; }
        public UserContext() :base() { Database.EnsureCreated(); }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=appbd;Trusted_Connection=True;");
        }
    }
}
