using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Db.Contexts;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
            {
                await _context.Users.AddAsync(user);
            }

            // Сохранение изменений
            await _context.SaveChangesAsync();
        }
    }

    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
