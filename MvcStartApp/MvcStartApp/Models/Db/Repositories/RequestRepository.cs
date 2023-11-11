using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db.Contexts;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db.Repositories
{

    public class RequestRepository: IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
            => _context = context;

        public async Task AddRequestAsync(Request request)
        {
            request.Id = Guid.NewGuid();
            request.Date = DateTime.Now;

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
            {
                await _context.Requests.AddAsync(request);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequestsAsync()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }

    interface IRequestRepository
    {
        Task AddRequestAsync(Request request);
        Task<Request[]> GetRequests();
    }
}
