using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Models.Db.Contexts
{
    public sealed class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }

        public BlogContext(DbContextOptions<BlogContext > options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
