using confBack.Models;
using Microsoft.EntityFrameworkCore;

namespace confBack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
