using Microsoft.EntityFrameworkCore;

namespace GameListRazor.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Game> Game { get; set; }
    }
}
