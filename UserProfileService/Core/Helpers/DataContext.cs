using Microsoft.EntityFrameworkCore;
using UserProfileService.Core.Entities;

namespace UserProfileService.Core.Helpers
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("TestDb");
        }

        public DbSet<User> Users { get; set; }
    }
}
