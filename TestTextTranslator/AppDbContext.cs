using Microsoft.EntityFrameworkCore;

namespace TestTextTranslator
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasData(
            //        new User { Id = 1, Name = "Tom", Age = 23 },
            //        new User { Id = 2, Name = "Alice", Age = 26 },
            //        new User { Id = 3, Name = "Sam", Age = 28 }
            //);
        }
    }
}
