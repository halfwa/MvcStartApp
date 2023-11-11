using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MvcStartApp.Models.Db.Contexts
{
    public sealed class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext > options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
