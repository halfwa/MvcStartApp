using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db.Repositories;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class RequestController: Controller
    {
        private readonly IRequestRepository _repo;
        public RequestController(IRequestRepository repo) => _repo = repo;

        [HttpGet]
        [Route("/logs")]
        [Route("/Request/logs")]
        public async Task<IActionResult> logs()
        {
            var requests =  await _repo.GetRequestsAsync();
            return View(requests);
        }


    }
}
