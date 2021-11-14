using Microsoft.EntityFrameworkCore;

namespace GuestBookApp.Models
{
    public class PostManagerContext : DbContext
    {
        public PostManagerContext(DbContextOptions<PostManagerContext> options)
    : base(options)
        {
        }

        public DbSet<GuestBookApp.Models.Post> Posts { get; set; }
    }
}
